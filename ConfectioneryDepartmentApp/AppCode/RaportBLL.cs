using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryDepartmentApp.AppCode {
  internal class RaportBLL {
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECTSQL"];

    public double GetTotalAmountForCustomer(int CustomerId) {
      double totalAmount = 0.0;
      using (MySqlConnection connection = new MySqlConnection(_ConnString)) {
        string query = @"
      SELECT SUM(o.manual_total)  -- Використовуємо manual_total
      FROM orders o
      WHERE o.customer_id = @CustomerId";  // Отримуємо суму для всіх замовлень клієнта
        using (MySqlCommand command = new MySqlCommand(query, connection)) {
          command.Parameters.AddWithValue("@CustomerId", CustomerId);
          connection.Open();
          object result = command.ExecuteScalar();  // Використовуємо ExecuteScalar для отримання одиничного значення (сума)
          if (result != DBNull.Value) {
            totalAmount = Convert.ToDouble(result);  // Перетворення результату в тип double
          }
          connection.Close();
        }
      }
      return totalAmount;
    }

    public double GetTotalAmountForSupplier(int SupplierId) {
      double totalAmount = 0.0;

      using (MySqlConnection connection = new MySqlConnection(_ConnString)) {
        string query = @"
      SELECT SUM(s.manual_total)   -- Використовуємо поле manual_total
      FROM supply_invoices s
      WHERE s.supplier_id = @SupplierId";  // Сумуємо всі накладні конкретного постачальника

        using (MySqlCommand command = new MySqlCommand(query, connection)) {
          command.Parameters.AddWithValue("@SupplierId", SupplierId);

          connection.Open();
          object result = command.ExecuteScalar();  // Отримуємо одне значення (загальну суму)
          if (result != DBNull.Value && result != null) {
            totalAmount = Convert.ToDouble(result);  // Перетворюємо у double
          }
          connection.Close();
        }
      }

      return totalAmount;
    }


    /// <summary>
    /// Аналіз найприбутковіших категорій за місяць.
    /// </summary>
    public List<CategoryRevenueReport> GetCategoryRevenueReportByMonth(DateTime selectedMonth) {
      var reportList = new List<CategoryRevenueReport>();
      // Початок і кінець обраного місяця
      DateTime startDate = new DateTime(selectedMonth.Year, selectedMonth.Month, 1);
      DateTime endDate = startDate.AddMonths(1).AddDays(-1);
      string sqlQuery = @"
      SELECT 
          c.category_name      AS CategoryName,
          SUM(oi.line_total)   AS TotalRevenue,
          COUNT(DISTINCT o.order_id) AS OrdersCount,
          ROUND(AVG(oi.unit_price), 2) AS AvgUnitPrice
      FROM order_items oi
      JOIN products p ON p.product_id = oi.product_id
      JOIN category c ON c.category_id = p.category_id
      JOIN orders o   ON o.order_id   = oi.order_id
      WHERE o.order_dt BETWEEN @startDate AND @endDate
      GROUP BY c.category_id, c.category_name
      ORDER BY TotalRevenue DESC;";

      using (var conn = new MySqlConnection(_ConnString)) {
        using (var cmd = new MySqlCommand(sqlQuery, conn)) {
          cmd.Parameters.AddWithValue("@startDate", startDate);
          cmd.Parameters.AddWithValue("@endDate", endDate);
          conn.Open();

          using (var reader = cmd.ExecuteReader()) {
            while (reader.Read()) {
              var item = new CategoryRevenueReport {
                CategoryName = reader["CategoryName"]?.ToString(),
                TotalRevenue = reader["TotalRevenue"] != DBNull.Value ? Convert.ToDecimal(reader["TotalRevenue"]) : 0m,
                OrdersCount = reader["OrdersCount"] != DBNull.Value ? Convert.ToInt32(reader["OrdersCount"]) : 0,
                AvgUnitPrice = reader["AvgUnitPrice"] != DBNull.Value ? Convert.ToDecimal(reader["AvgUnitPrice"]) : 0m
              };
              reportList.Add(item);
            }
          }
        }
      }
      return reportList;
    }

    /// <summary>
    /// Рейтинг клієнтів за сумою замовлень: manual_total (після знижки).
    /// Додатково повертається сума до знижки (із order_items) та середній чек.
    /// </summary>
    public List<CustomerRankingReport> GetCustomersRankingBySpent(int topN = 10) {
      var list = new List<CustomerRankingReport>();

      // 1) Перерахунок по кожному замовленню: BaseSum = сума позицій (до знижки),
      //    ManualTotal = підсумок після знижки/коригування (orders.manual_total).
      // 2) Агрегація по клієнту.
      string sql = $@"
      SELECT
          c.full_name                          AS CustomerName,
          COUNT(*)                             AS OrdersCount,
          SUM(t.BaseSum)                       AS TotalBeforeDiscount,
          SUM(COALESCE(t.ManualTotal, t.BaseSum)) AS TotalAfterDiscount,
          ROUND(AVG(COALESCE(t.ManualTotal, t.BaseSum)), 2) AS AvgOrderAfterDiscount
      FROM (
          SELECT 
              o.order_id,
              o.customer_id,
              o.manual_total AS ManualTotal,
              SUM(oi.line_total) AS BaseSum
          FROM orders o
          JOIN order_items oi ON oi.order_id = o.order_id
          GROUP BY o.order_id, o.customer_id, o.manual_total
      ) t
      JOIN customers c ON c.customer_id = t.customer_id
      GROUP BY t.customer_id, c.full_name
      ORDER BY TotalAfterDiscount DESC
      LIMIT @topN;";

      using (var cn = new MySqlConnection(_ConnString)) {
        using (var cmd = new MySqlCommand(sql, cn)) {
          cmd.Parameters.AddWithValue("@topN", topN);
          cn.Open();
          using (var r = cmd.ExecuteReader()) {
            while (r.Read()) {
              var item = new CustomerRankingReport {
                CustomerName = r["CustomerName"]?.ToString(),
                OrdersCount = r["OrdersCount"] != DBNull.Value ? Convert.ToInt32(r["OrdersCount"]) : 0,
                TotalBeforeDiscount = r["TotalBeforeDiscount"] != DBNull.Value ? Convert.ToDecimal(r["TotalBeforeDiscount"]) : 0m,
                TotalAfterDiscount = r["TotalAfterDiscount"] != DBNull.Value ? Convert.ToDecimal(r["TotalAfterDiscount"]) : 0m,
                AvgOrderAfterDiscount = r["AvgOrderAfterDiscount"] != DBNull.Value ? Convert.ToDecimal(r["AvgOrderAfterDiscount"]) : 0m
              };
              list.Add(item);
            }
          }
        }
      }
      return list;
    }

    /// <summary>
    /// ТОП-N популярних товарів за весь час (кількість та дохід, частка у загальному доході).
    /// </summary>
    public List<ProductPopularityReport> GetTopProductsPopularity(int topN = 10) {
      var list = new List<ProductPopularityReport>();

      string sql = @"
      SELECT
          p.product_name AS ProductName,
          c.category_name AS CategoryName,
          SUM(oi.qty) AS QtySold,
          SUM(oi.line_total) AS RevenueTotal,
          ROUND(
            SUM(oi.line_total) * 100 /
            (SELECT COALESCE(SUM(line_total), 0) FROM order_items)
          , 2) AS RevenueSharePct
      FROM order_items oi
      JOIN products p ON p.product_id = oi.product_id
      JOIN category c ON c.category_id = p.category_id
      GROUP BY p.product_id, p.product_name, c.category_name
      ORDER BY RevenueTotal DESC
      LIMIT @topN;";

      using (var cn = new MySqlConnection(_ConnString))
      using (var cmd = new MySqlCommand(sql, cn)) {
        cmd.Parameters.AddWithValue("@topN", topN);
        cn.Open();
        using (var r = cmd.ExecuteReader()) {
          while (r.Read()) {
            list.Add(new ProductPopularityReport {
              ProductName = r["ProductName"]?.ToString(),
              CategoryName = r["CategoryName"]?.ToString(),
              QtySold = r["QtySold"] != DBNull.Value ? Convert.ToDecimal(r["QtySold"]) : 0m,
              RevenueTotal = r["RevenueTotal"] != DBNull.Value ? Convert.ToDecimal(r["RevenueTotal"]) : 0m,
              RevenueSharePct = r["RevenueSharePct"] != DBNull.Value ? Convert.ToDecimal(r["RevenueSharePct"]) : 0m
            });
          }
        }
      }
      return list;
    }

    /// <summary>
    /// ТОП-N популярних товарів за ОБРАНИЙ МІСЯЦЬ (межі — перший і останній день місяця).
    /// Частка рахується в межах цього ж місяця.
    /// </summary>
    public List<ProductPopularityReport> GetTopProductsPopularityByMonth(DateTime selectedMonth, int topN = 10) {
      var list = new List<ProductPopularityReport>();

      DateTime startDate = new DateTime(selectedMonth.Year, selectedMonth.Month, 1);
      DateTime endDate = startDate.AddMonths(1).AddDays(-1);

      string sql = @"
      SELECT
          p.product_name AS ProductName,
          c.category_name AS CategoryName,
          SUM(oi.qty) AS QtySold,
          SUM(oi.line_total) AS RevenueTotal,
          ROUND(
            SUM(oi.line_total) * 100 /
            (
              SELECT COALESCE(SUM(oi2.line_total), 0)
              FROM order_items oi2
              JOIN orders o2 ON o2.order_id = oi2.order_id
              WHERE o2.order_dt BETWEEN @startDate AND @endDate
            )
          , 2) AS RevenueSharePct
      FROM order_items oi
      JOIN products p ON p.product_id = oi.product_id
      JOIN category c ON c.category_id = p.category_id
      JOIN orders o ON o.order_id = oi.order_id
      WHERE o.order_dt BETWEEN @startDate AND @endDate
      GROUP BY p.product_id, p.product_name, c.category_name
      ORDER BY RevenueTotal DESC
      LIMIT @topN;";

      using (var cn = new MySqlConnection(_ConnString))
      using (var cmd = new MySqlCommand(sql, cn)) {
        cmd.Parameters.AddWithValue("@startDate", startDate);
        cmd.Parameters.AddWithValue("@endDate", endDate);
        cmd.Parameters.AddWithValue("@topN", topN);

        cn.Open();
        using (var r = cmd.ExecuteReader()) {
          while (r.Read()) {
            list.Add(new ProductPopularityReport {
              ProductName = r["ProductName"]?.ToString(),
              CategoryName = r["CategoryName"]?.ToString(),
              QtySold = r["QtySold"] != DBNull.Value ? Convert.ToDecimal(r["QtySold"]) : 0m,
              RevenueTotal = r["RevenueTotal"] != DBNull.Value ? Convert.ToDecimal(r["RevenueTotal"]) : 0m,
              RevenueSharePct = r["RevenueSharePct"] != DBNull.Value ? Convert.ToDecimal(r["RevenueSharePct"]) : 0m
            });
          }
        }
      }
      return list;
    }

    public List<ProductSaleInfo> GetSoldProductsInfo(DateTime startDate, DateTime endDate) {
      var salesInfo = new List<ProductSaleInfo>();

      using (var connection = new MySqlConnection(_ConnString)) {
        string query = @"
      SELECT 
          p.product_name AS ProductName,
          ROUND(oi.unit_price, 2) AS SalePrice,
          SUM(oi.qty) AS QuantitySold,
          SUM(oi.line_total) AS TotalSale,
          MIN(o.order_dt) AS OrderDate,
          MIN(o.order_id) AS OrderId
      FROM order_items oi
      JOIN orders o ON o.order_id = oi.order_id
      JOIN products p ON p.product_id = oi.product_id
      WHERE 
          o.status = 'видано'
          AND o.order_dt BETWEEN @StartDate AND @EndDate
      GROUP BY 
          p.product_id, p.product_name, oi.unit_price
      ORDER BY 
          TotalSale DESC;";

        using (var cmd = new MySqlCommand(query, connection)) {
          cmd.Parameters.AddWithValue("@StartDate", startDate);
          cmd.Parameters.AddWithValue("@EndDate", endDate);

          connection.Open();
          using (var reader = cmd.ExecuteReader()) {
            while (reader.Read()) {
              salesInfo.Add(new ProductSaleInfo {
                OrderId = Convert.ToInt32(reader["OrderId"]),
                OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                ProductName = reader["ProductName"].ToString(),
                QuantitySold = Convert.ToDouble(reader["QuantitySold"]),
                SalePrice = Convert.ToDouble(reader["SalePrice"]),
                TotalSale = Convert.ToDouble(reader["TotalSale"])
              });
            }
          }
        }
      }

      return salesInfo;
    }


  }
}



// DTO звіту
public class CategoryRevenueReport {
  public string CategoryName { get; set; }
  public decimal TotalRevenue { get; set; }
  public int OrdersCount { get; set; }
  public decimal AvgUnitPrice { get; set; }
}

public class CustomerRankingReport {
  public string CustomerName { get; set; }
  public int OrdersCount { get; set; }
  public decimal TotalBeforeDiscount { get; set; } // сума позицій (без знижок)
  public decimal TotalAfterDiscount { get; set; }  // manual_total (зі знижками/коригуваннями)
  public decimal AvgOrderAfterDiscount { get; set; } // середній чек після знижки
}

public class ProductPopularityReport {
  public string ProductName { get; set; }
  public string CategoryName { get; set; }
  public decimal QtySold { get; set; }        // сумарна кількість проданих одиниць
  public decimal RevenueTotal { get; set; }   // сумарний дохід по товару
  public decimal RevenueSharePct { get; set; } // частка у загальному доході, %
}

public class ProductSaleInfo {
  public int OrderId { get; set; }
  public DateTime OrderDate { get; set; }
  public string ProductName { get; set; }
  public double QuantitySold { get; set; }
  public double SalePrice { get; set; }
  public double TotalSale { get; set; }
}
