using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryDepartmentApp.Providers {
  internal class GenDataConfact {
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECTSQL"];

    public void InsertDefaultCategories() {
      using (var connection = new MySqlConnection(_ConnString)) {
        connection.Open();

        var categories = new List<(string Name, string Description)> {
      ("Торти", "Великі та порційні торти власного виробництва на бісквітній та пісочній основі."),
      ("Печиво", "Асортимент домашнього, вівсяного та пісочного печива різних форм."),
      ("Цукерки", "Ручної роботи цукерки з начинками, трюфелі та праліне."),
      ("Пиріжки", "Солодкі та солоні пиріжки із дріжджового та листкового тіста."),
      ("Кекси", "Порційні кекси з шоколадом, ягодами та горіхами."),
      ("Рулети", "Бісквітні та дріжджові рулети з кремом, маком чи варенням."),
      ("Тістечка", "Індивідуальні десерти: еклери, корзинки, наполеон тощо."),
      ("Випічка до чаю", "Асортимент здоби та булочок для повсякденного споживання."),
      ("Дієтична продукція", "Вироби без цукру, з цільнозернового борошна та натуральних підсолоджувачів."),
      ("Сезонні десерти", "Продукція, виготовлена за святковими або сезонними рецептами.")
    };

        foreach (var (name, description) in categories) {
          string query = "INSERT INTO category (category_name, description) VALUES (@Name, @Description)";
          using (var cmd = new MySqlCommand(query, connection)) {
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Description", description);
            cmd.ExecuteNonQuery();
          }
        }

        connection.Close();
      }
    }

    public void InsertDefaultProducts() {
      using (var connection = new MySqlConnection(_ConnString)) {
        connection.Open();

        // Категорії 1..10 (по два товари на кожну)
        var products = new List<(string Sku, string Name, int CategoryId, double Price, int PrepTime, string Unit, string Notes)>
        {
      // 1. Торти
      ("T001", "Торт «Київський»", 1, 480.00, 180, "шт.", "Класичний бісквітний торт з горіхами та кремом."),
      ("T002", "Торт «Наполеон»", 1, 420.00, 150, "шт.", "Шарований торт із заварним кремом."),

      // 2. Печиво
      ("P001", "Печиво вівсяне", 2, 150.00, 60, "кг", "Домашнє вівсяне печиво з медом і родзинками."),
      ("P002", "Печиво пісочне", 2, 140.00, 45, "кг", "Пісочне печиво з ваніліном і лимонною цедрою."),

      // 3. Цукерки
      ("C001", "Цукерки «Трюфель»", 3, 300.00, 90, "кг", "Ручної роботи шоколадні трюфелі з какао."),
      ("C002", "Цукерки «Праліне»", 3, 320.00, 100, "кг", "Шоколадні цукерки з горіховою начинкою."),

      // 4. Пиріжки
      ("PY001", "Пиріжки з вишнею", 4, 90.00, 40, "кг", "Солодкі пиріжки із соковитою вишнею."),
      ("PY002", "Пиріжки з капустою", 4, 85.00, 35, "кг", "Домашні пиріжки із тушкованою капустою."),

      // 5. Кекси
      ("K001", "Кекс шоколадний", 5, 70.00, 50, "шт.", "М’який шоколадний кекс із какао."),
      ("K002", "Кекс лимонний", 5, 65.00, 45, "шт.", "Кекс із лимонною цедрою та глазур’ю."),

      // 6. Рулети
      ("R001", "Рулет маковий", 6, 160.00, 80, "шт.", "Дріжджовий рулет із маковою начинкою."),
      ("R002", "Рулет з варенням", 6, 150.00, 70, "шт.", "Бісквітний рулет із полуничним варенням."),

      // 7. Тістечка
      ("TS001", "Еклер з кремом", 7, 55.00, 30, "шт.", "Заварне тістечко з вершковим кремом."),
      ("TS002", "Корзинка з фруктами", 7, 60.00, 35, "шт.", "Пісочне тістечко з кремом і фруктами."),

      // 8. Випічка до чаю
      ("V001", "Булочка з корицею", 8, 40.00, 30, "шт.", "Ароматна здоба з корицею."),
      ("V002", "Рогалик з джемом", 8, 45.00, 35, "шт.", "М’який рогалик з абрикосовим джемом."),

      // 9. Дієтична продукція
      ("D001", "Печиво без цукру", 9, 180.00, 55, "кг", "Дієтичне вівсяне печиво з фруктозою."),
      ("D002", "Кекс з висівками", 9, 160.00, 60, "шт.", "Кекс із висівками та родзинками."),

      // 10. Сезонні десерти
      ("S001", "Паска великодня", 10, 200.00, 90, "шт.", "Святкова паска з родзинками та цукатами."),
      ("S002", "Пряники новорічні", 10, 180.00, 75, "кг", "Медові пряники з глазур’ю у святковому оформленні.")
    };

        foreach (var p in products) {
          string query = @"
        INSERT INTO products 
          (sku, product_name, category_id, base_price, prep_time_min, photo_data, unit, notes)
        VALUES
          (@Sku, @ProductName, @CategoryId, @BasePrice, @PrepTimeMin, NULL, @Unit, @Notes)";

          using (var cmd = new MySqlCommand(query, connection)) {
            cmd.Parameters.AddWithValue("@Sku", p.Sku);
            cmd.Parameters.AddWithValue("@ProductName", p.Name);
            cmd.Parameters.AddWithValue("@CategoryId", p.CategoryId);
            cmd.Parameters.AddWithValue("@BasePrice", p.Price);
            cmd.Parameters.AddWithValue("@PrepTimeMin", p.PrepTime);
            cmd.Parameters.AddWithValue("@Unit", p.Unit);
            cmd.Parameters.AddWithValue("@Notes", p.Notes);
            cmd.ExecuteNonQuery();
          }
        }

        connection.Close();
      }
    }

    public void InsertDefaultCustomers() {
      using (var connection = new MySqlConnection(_ConnString)) {
        connection.Open();

        var customers = new List<(string FullName, string Phone, string Email, double DiscountPct)>
        {
      ("Іваненко Марія Петрівна", "+380671112233", "m.ivanenko@gmail.com", 5.0),
      ("Петренко Олександр Ігорович", "+380672224455", "o.petrenko@ukr.net", 3.0),
      ("Сидоренко Ольга Василівна", "+380673336677", "olga.sid@gmail.com", 2.0),
      ("Шевченко Андрій Михайлович", "+380674447799", "a.shevchenko@meta.ua", 7.0),
      ("Коваленко Ірина Степанівна", "+380675558811", "irina.kovalenko@gmail.com", 5.0),
      ("Бондар Віталій Олегович", "+380676669933", "v.bondar@ukr.net", 4.0),
      ("Мельник Оксана Юріївна", "+380677771155", "oksana.melnyk@gmail.com", 6.0),
      ("Кравченко Дмитро Сергійович", "+380678882377", "d.kravchenko@ukr.net", 3.5),
      ("Гриценко Наталія Павлівна", "+380679993599", "n.grytsenko@gmail.com", 2.5),
      ("Романюк Олексій Іванович", "+380680104711", "oleksiy.romaniuk@gmail.com", 4.5),
      ("Лисенко Юлія Вікторівна", "+380681215933", "y.lysenko@meta.ua", 5.0),
      ("Кириченко Артем Валерійович", "+380682327155", "artem.kirichenko@ukr.net", 3.0),
      ("Поліщук Катерина Анатоліївна", "+380683438377", "k.polishchuk@gmail.com", 6.5),
      ("Данилюк Богдан Миколайович", "+380684549599", "b.danyliuk@gmail.com", 2.0),
      ("Савченко Тетяна Юріївна", "+380685650811", "t.savchenko@ukr.net", 5.5),
      ("Ткаченко Владислав Олегович", "+380686761033", "v.tkachenko@gmail.com", 4.0),
      ("Мороз Анастасія Сергіївна", "+380687872255", "a.moroz@gmail.com", 3.5),
      ("Черненко Павло Вікторович", "+380688983477", "p.chernenko@ukr.net", 2.5),
      ("Левченко Ганна Іванівна", "+380689094699", "h.levchenko@gmail.com", 4.5),
      ("Білик Олег Степанович", "+380680205911", "oleg.bilyk@gmail.com", 5.0)
    };

        foreach (var c in customers) {
          string query = "INSERT INTO customers (full_name, phone, email, discount_pct) VALUES (@FullName, @Phone, @Email, @DiscountPct)";
          using (var cmd = new MySqlCommand(query, connection)) {
            cmd.Parameters.AddWithValue("@FullName", c.FullName);
            cmd.Parameters.AddWithValue("@Phone", c.Phone);
            cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(c.Email) ? (object)DBNull.Value : c.Email);
            cmd.Parameters.AddWithValue("@DiscountPct", c.DiscountPct);
            cmd.ExecuteNonQuery();
          }
        }

        connection.Close();
      }
    }

    /// <summary>
    /// Додає count (за замовчуванням 20) замовлень за останні 2 місяці.
    /// У кожному замовленні 2–5 позицій. manual_total = сума після знижки клієнта.
    /// </summary>
    public void InsertRandomOrdersLast2Months(int count = 20) {
      var rnd = new Random();

      using (var cn = new MySqlConnection(_ConnString)) {
        cn.Open();

        // 1) Підтягнути клієнтів (id + знижка)
        var customers = new List<(int CustomerId, decimal DiscountPct)>();
        using (var cmd = new MySqlCommand(
          @"SELECT customer_id, discount_pct FROM customers ORDER BY customer_id;", cn)) {
          using (var r = cmd.ExecuteReader()) {
            while (r.Read()) {
              int id = Convert.ToInt32(r["customer_id"]);
              decimal disc = r["discount_pct"] != DBNull.Value ? Convert.ToDecimal(r["discount_pct"]) : 0m;
              customers.Add((id, disc));
            }
          }
        }
        if (customers.Count == 0) throw new InvalidOperationException("Немає клієнтів для створення замовлень.");

        // 2) Підтягнути товари (id + ціна)
        var products = new List<(int ProductId, decimal BasePrice)>();
        using (var cmd = new MySqlCommand(
          @"SELECT product_id, base_price FROM products ORDER BY product_id;", cn)) {
          using (var r = cmd.ExecuteReader()) {
            while (r.Read()) {
              int id = Convert.ToInt32(r["product_id"]);
              decimal price = Convert.ToDecimal(r["base_price"]);
              products.Add((id, price));
            }
          }
        }
        if (products.Count < 2) throw new InvalidOperationException("Недостатньо товарів (потрібно ≥ 2).");

        string[] statuses = new[] { "нове", "в роботі", "видано" };

        for (int i = 0; i < count; i++) {
          using (var tx = cn.BeginTransaction()) {
            try {
              // 3) Випадковий клієнт і його знижка
              var cust = customers[rnd.Next(customers.Count)];
              decimal discountPct = cust.DiscountPct;

              // 4) Дата замовлення в межах останніх 60 днів
              DateTime now = DateTime.Now;
              int backDays = rnd.Next(0, 60); // 0..59
              DateTime orderDt = now.AddDays(-backDays);
              DateTime? dueDt = orderDt.AddDays(rnd.Next(1, 8)); // 1..7 днів

              // 5) Випадковий статус і нотатка
              string status = statuses[rnd.Next(statuses.Length)];
              string notes = $"Автогенероване замовлення #{i + 1} (seed)";

              // 6) Згенерувати позиції: 2..5 унікальних товарів
              int itemsCount = rnd.Next(2, 6);
              var shuffled = products.OrderBy(_ => rnd.Next()).Take(itemsCount).ToList();

              var items = new List<(int ProductId, decimal Qty, decimal UnitPrice)>();
              foreach (var pr in shuffled) {
                // кількість 1.00 .. 3.00 з кроком 0.5
                decimal qty = 1m + 0.5m * rnd.Next(0, 5); // 1.0,1.5,2.0,2.5,3.0
                decimal unitPrice = pr.BasePrice;         // за умовою — з products.base_price
                items.Add((pr.ProductId, qty, unitPrice));
              }

              // 7) Підсумки: сума по позиціях та знижка
              decimal gross = items.Sum(x => Math.Round(x.Qty * x.UnitPrice, 2, MidpointRounding.AwayFromZero));
              decimal totalAfterDiscount = Math.Round(gross * (1 - discountPct / 100m), 2, MidpointRounding.AwayFromZero);

              // 8) Вставити заголовок замовлення (з order_dt та manual_total)
              long orderId;
              using (var cmd = new MySqlCommand(@"
              INSERT INTO orders (customer_id, status, order_dt, due_dt, notes, manual_total)
              VALUES (@CustomerId,   @Status,   @OrderDt, @DueDt, @Notes, @ManualTotal);", cn, tx)) {
                cmd.Parameters.AddWithValue("@CustomerId", cust.CustomerId);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@OrderDt", orderDt);
                cmd.Parameters.AddWithValue("@DueDt", (object)dueDt ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Notes", (object)notes ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ManualTotal", totalAfterDiscount);
                cmd.ExecuteNonQuery();
                orderId = cmd.LastInsertedId;
              }

              // 9) Вставити позиції замовлення
              using (var cmd = new MySqlCommand(@"
              INSERT INTO order_items (order_id, product_id, qty, unit_price)
              VALUES (@OrderId, @ProductId, @Qty, @UnitPrice);", cn, tx)) {
                cmd.Parameters.Add("@OrderId", MySqlDbType.Int32);
                cmd.Parameters.Add("@ProductId", MySqlDbType.Int32);
                cmd.Parameters.Add("@Qty", MySqlDbType.Decimal);
                cmd.Parameters.Add("@UnitPrice", MySqlDbType.Decimal);

                foreach (var it in items) {
                  cmd.Parameters["@OrderId"].Value = orderId;
                  cmd.Parameters["@ProductId"].Value = it.ProductId;
                  cmd.Parameters["@Qty"].Value = it.Qty;
                  cmd.Parameters["@UnitPrice"].Value = it.UnitPrice;
                  cmd.ExecuteNonQuery();
                }
              }

              tx.Commit();
            } catch {
              tx.Rollback();
              throw; // прокидаємо для діагностики; можна логувати і продовжувати цикл
            }
          } // using tx
        } // for
      } // using cn
    }


    public void SeedSuppliers() {
      // Список тестових постачальників
      var suppliers = new List<(string Name, string Address, string Email, string Phone)> {
    ("ТОВ «АгроТрейд Україна»",     "м. Київ, вул. Промислова, 12",      "info@agrotrade.ua",       "+380441234567"),
    ("ПП «ФудСервіс Груп»",         "м. Львів, вул. Зелена, 45",        "sales@foodservice.ua",    "+380322234578"),
    ("ТОВ «ТехноПоставка»",          "м. Харків, пр. Науки, 9",          "office@technosupply.ua",  "+380577654321"),
    ("ТОВ «БудІнвест»",              "м. Дніпро, вул. Будівельників, 17","contact@budinvest.ua",    "+380567893210"),
    ("ПП «МолПродукт»",              "м. Полтава, вул. Європейська, 23", "info@molproduct.ua",      "+380532112233"),
    ("ТОВ «Світ Напоїв»",            "м. Одеса, вул. Академічна, 10",    "order@drinksworld.ua",    "+380482445566"),
    ("ТОВ «ФармаПостач»",            "м. Черкаси, вул. Медична, 4",      "supply@pharmapostach.ua", "+380472889900"),
    ("ТОВ «ЕкоМаркет Плюс»",         "м. Вінниця, вул. Келецька, 120",   "info@ecomarket.ua",       "+380432778899"),
    ("ПП «ХарчПром»",                "м. Рівне, вул. Миру, 8",           "support@harchprom.ua",    "+380362667788"),
    ("ТОВ «Солодкий Світ»",          "м. Тернопіль, вул. Франка, 15",    "office@slodsweet.ua",     "+380352554433")
  };

      using (MySqlConnection connection = new MySqlConnection(_ConnString)) {
        string query = "INSERT INTO suppliers (SupplierName, Address, Email, Phone) VALUES(@SupplierName, @Address, @Email, @Phone)";
        MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.Parameters.Add("@SupplierName", MySqlDbType.VarChar);
        cmd.Parameters.Add("@Address", MySqlDbType.VarChar);
        cmd.Parameters.Add("@Email", MySqlDbType.VarChar);
        cmd.Parameters.Add("@Phone", MySqlDbType.VarChar);

        connection.Open();

        foreach (var s in suppliers) {
          cmd.Parameters["@SupplierName"].Value = s.Name;
          cmd.Parameters["@Address"].Value = s.Address;
          cmd.Parameters["@Email"].Value = s.Email;
          cmd.Parameters["@Phone"].Value = s.Phone;
          cmd.ExecuteNonQuery();
        }

        connection.Close();
      }
    }


  }
}
