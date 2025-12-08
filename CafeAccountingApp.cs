using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;

namespace AistCafeAccounting
{
    // Класс для представления товара
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime LastRestockDate { get; set; }

        public override string ToString()
        {
            return $"ID: {Id,-3} | {Name,-20} | Категория: {Category,-12} | Цена: {Price,8:C} | Количество: {Quantity,4}";
        }
    }

    // Класс для представления заказа
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }

        public Order()
        {
            Items = new List<OrderItem>();
            OrderDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Заказ #{Id} | Дата: {OrderDate:dd.MM.yyyy HH:mm} | Сумма: {TotalAmount:C} | Метод оплаты: {PaymentMethod}";
        }
    }

    // Класс для элемента заказа
    public class OrderItem
    {
        public MenuItem Product { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }

        public override string ToString()
        {
            return $"  {Product.Name,-20} x{Quantity,2} = {Subtotal,10:C}";
        }
    }

    // Класс для представления сотрудника
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }

        public override string ToString()
        {
            return $"ID: {Id,-3} | {Name,-20} | Должность: {Position,-15} | Телефон: {Phone,-12} | Зарплата: {Salary,10:C}";
        }
    }

    // Главный класс приложения
    public class CafeAccountingSystem
    {
        private List<MenuItem> menuItems;
        private List<Order> orders;
        private List<Employee> employees;
        private int nextMenuId = 1;
        private int nextOrderId = 1;
        private int nextEmployeeId = 1;

        public CafeAccountingSystem()
        {
            menuItems = new List<MenuItem>();
            orders = new List<Order>();
            employees = new List<Employee>();
            InitializeSampleData();
        }

        // Инициализация примерных данных
        private void InitializeSampleData()
        {
            // Добавляем примеры товаров
            menuItems.Add(new MenuItem { Id = nextMenuId++, Name = "Капучино", Category = "Кофе", Price = 120m, Quantity = 50, LastRestockDate = DateTime.Now });
            menuItems.Add(new MenuItem { Id = nextMenuId++, Name = "Эспрессо", Category = "Кофе", Price = 80m, Quantity = 60, LastRestockDate = DateTime.Now });
            menuItems.Add(new MenuItem { Id = nextMenuId++, Name = "Латте", Category = "Кофе", Price = 130m, Quantity = 45, LastRestockDate = DateTime.Now });
            menuItems.Add(new MenuItem { Id = nextMenuId++, Name = "Американо", Category = "Кофе", Price = 90m, Quantity = 70, LastRestockDate = DateTime.Now });
            menuItems.Add(new MenuItem { Id = nextMenuId++, Name = "Круассан", Category = "Выпечка", Price = 80m, Quantity = 30, LastRestockDate = DateTime.Now });
            menuItems.Add(new MenuItem { Id = nextMenuId++, Name = "Чизкейк", Category = "Десерты", Price = 150m, Quantity = 20, LastRestockDate = DateTime.Now });
            menuItems.Add(new MenuItem { Id = nextMenuId++, Name = "Зелёный чай", Category = "Напитки", Price = 100m, Quantity = 40, LastRestockDate = DateTime.Now });

            // Добавляем примеры сотрудников
            employees.Add(new Employee { Id = nextEmployeeId++, Name = "Иван Петров", Position = "Бариста", Phone = "+7-900-123-45-67", Salary = 35000m, HireDate = new DateTime(2023, 6, 15) });
            employees.Add(new Employee { Id = nextEmployeeId++, Name = "Мария Сидорова", Position = "Кассир", Phone = "+7-900-234-56-78", Salary = 30000m, HireDate = new DateTime(2023, 8, 20) });
            employees.Add(new Employee { Id = nextEmployeeId++, Name = "Александр Иванов", Position = "Менеджер", Phone = "+7-900-345-67-89", Salary = 50000m, HireDate = new DateTime(2022, 1, 10) });
        }

        // Главное меню
        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("════════════════════════════════════════════════════════════");
                Console.WriteLine("     ИНФОРМАЦИОННАЯ СИСТЕМА УЧЕТА КОФЕЙНИ 'АИСТ'");
                Console.WriteLine("════════════════════════════════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine("1. Управление меню и товарами");
                Console.WriteLine("2. Управление заказами");
                Console.WriteLine("3. Управление сотрудниками");
                Console.WriteLine("4. Отчёты и статистика");
                Console.WriteLine("5. Выход");
                Console.WriteLine();
                Console.Write("Выберите пункт меню (1-5): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        MenuManagement();
                        break;
                    case "2":
                        OrderManagement();
                        break;
                    case "3":
                        EmployeeManagement();
                        break;
                    case "4":
                        Reports();
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("До свидания!");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        // Управление меню
        private void MenuManagement()
        {
            bool managing = true;
            while (managing)
            {
                Console.Clear();
                Console.WriteLine("═══════════════════════════════════════════════════════");
                Console.WriteLine("           УПРАВЛЕНИЕ МЕНЮ И ТОВАРАМИ");
                Console.WriteLine("═══════════════════════════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine("1. Просмотреть все товары");
                Console.WriteLine("2. Добавить новый товар");
                Console.WriteLine("3. Обновить товар");
                Console.WriteLine("4. Удалить товар");
                Console.WriteLine("5. Проверить товары с низким количеством");
                Console.WriteLine("6. Вернуться в главное меню");
                Console.WriteLine();
                Console.Write("Выберите действие (1-6): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ViewAllMenuItems();
                        break;
                    case "2":
                        AddMenuItem();
                        break;
                    case "3":
                        UpdateMenuItem();
                        break;
                    case "4":
                        DeleteMenuItem();
                        break;
                    case "5":
                        CheckLowStock();
                        break;
                    case "6":
                        managing = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void ViewAllMenuItems()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("                             ВСЕ ТОВАРЫ");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine();

            if (menuItems.Count == 0)
            {
                Console.WriteLine("Товаров нет.");
            }
            else
            {
                // Группировка по категориям
                var grouped = menuItems.GroupBy(m => m.Category);
                foreach (var group in grouped)
                {
                    Console.WriteLine($"\n📁 Категория: {group.Key}");
                    Console.WriteLine(new string('-', 87));
                    foreach (var item in group)
                    {
                        Console.WriteLine(item);
                    }
                }
            }

            Console.WriteLine("\nНажмите Enter для продолжения...");
            Console.ReadLine();
        }

        private void AddMenuItem()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════");
            Console.WriteLine("                    ДОБАВИТЬ ТОВАР");
            Console.WriteLine("═══════════════════════════════════════════════════════");
            Console.WriteLine();

            Console.Write("Введите название товара: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Название не может быть пустым.");
                Console.ReadLine();
                return;
            }

            Console.Write("Введите категорию: ");
            string category = Console.ReadLine();

            Console.Write("Введите цену: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price < 0)
            {
                Console.WriteLine("Неверная цена.");
                Console.ReadLine();
                return;
            }

            Console.Write("Введите количество: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
            {
                Console.WriteLine("Неверное количество.");
                Console.ReadLine();
                return;
            }

            menuItems.Add(new MenuItem
            {
                Id = nextMenuId++,
                Name = name,
                Category = category,
                Price = price,
                Quantity = quantity,
                LastRestockDate = DateTime.Now
            });

            Console.WriteLine($"\n✓ Товар '{name}' успешно добавлен.");
            Console.ReadLine();
        }

        private void UpdateMenuItem()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════");
            Console.WriteLine("                    ОБНОВИТЬ ТОВАР");
            Console.WriteLine("═══════════════════════════════════════════════════════");
            Console.WriteLine();

            Console.Write("Введите ID товара для обновления: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Неверный ID.");
                Console.ReadLine();
                return;
            }

            var item = menuItems.FirstOrDefault(m => m.Id == id);
            if (item == null)
            {
                Console.WriteLine("Товар не найден.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"\nТекущие данные: {item}");
            Console.WriteLine();

            Console.Write("Введите новое название (Enter для пропуска): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                item.Name = name;

            Console.Write("Введите новую цену (Enter для пропуска): ");
            string priceInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(priceInput) && decimal.TryParse(priceInput, out decimal price))
                item.Price = price;

            Console.Write("Введите новое количество (Enter для пропуска): ");
            string qtyInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(qtyInput) && int.TryParse(qtyInput, out int quantity))
                item.Quantity = quantity;

            Console.WriteLine($"\n✓ Товар успешно обновлён.");
            Console.ReadLine();
        }

        private void DeleteMenuItem()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════");
            Console.WriteLine("                    УДАЛИТЬ ТОВАР");
            Console.WriteLine("═══════════════════════════════════════════════════════");
            Console.WriteLine();

            Console.Write("Введите ID товара для удаления: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Неверный ID.");
                Console.ReadLine();
                return;
            }

            var item = menuItems.FirstOrDefault(m => m.Id == id);
            if (item == null)
            {
                Console.WriteLine("Товар не найден.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"\nВы уверены, что хотите удалить '{item.Name}'? (д/н): ");
            if (Console.ReadLine().ToLower() == "д")
            {
                menuItems.Remove(item);
                Console.WriteLine("✓ Товар удалён.");
            }
            else
            {
                Console.WriteLine("✗ Удаление отменено.");
            }
            Console.ReadLine();
        }

        private void CheckLowStock()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("                    ТОВАРЫ С НИЗКИМ КОЛИЧЕСТВОМ (< 30)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine();

            var lowStock = menuItems.Where(m => m.Quantity < 30).ToList();

            if (lowStock.Count == 0)
            {
                Console.WriteLine("✓ Все товары в наличии в нормальном количестве.");
            }
            else
            {
                foreach (var item in lowStock.OrderBy(m => m.Quantity))
                {
                    Console.WriteLine($"⚠️  {item.Name,-20} Количество: {item.Quantity,3} | Категория: {item.Category}");
                }
                Console.WriteLine($"\nВсего товаров с низким запасом: {lowStock.Count}");
            }

            Console.WriteLine("\nНажмите Enter для продолжения...");
            Console.ReadLine();
        }

        // Управление заказами
        private void OrderManagement()
        {
            bool managing = true;
            while (managing)
            {
                Console.Clear();
                Console.WriteLine("═══════════════════════════════════════════════════════");
                Console.WriteLine("              УПРАВЛЕНИЕ ЗАКАЗАМИ");
                Console.WriteLine("═══════════════════════════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine("1. Создать новый заказ");
                Console.WriteLine("2. Просмотреть все заказы");
                Console.WriteLine("3. Просмотреть детали заказа");
                Console.WriteLine("4. Вернуться в главное меню");
                Console.WriteLine();
                Console.Write("Выберите действие (1-4): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        CreateOrder();
                        break;
                    case "2":
                        ViewAllOrders();
                        break;
                    case "3":
                        ViewOrderDetails();
                        break;
                    case "4":
                        managing = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void CreateOrder()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════════");
            Console.WriteLine("                    СОЗДАТЬ НОВЫЙ ЗАКАЗ");
            Console.WriteLine("═══════════════════════════════════════════════════════");
            Console.WriteLine();

            var order = new Order { Id = nextOrderId++ };

            bool addingItems = true;
            while (addingItems)
            {
                Console.WriteLine("\nДоступные товары:");
                ViewAllMenuItems();

                Console.Write("Введите ID товара (0 для завершения): ");
                if (!int.TryParse(Console.ReadLine(), out int menuId) || menuId == 0)
                {
                    if (order.Items.Count == 0)
                    {
                        Console.WriteLine("Заказ не может быть пустым.");
                        Console.ReadLine();
                        continue;
                    }
                    addingItems = false;
                    break;
                }

                var item = menuItems.FirstOrDefault(m => m.Id == menuId);
                if (item == null)
                {
                    Console.WriteLine("Товар не найден.");
                    Console.ReadLine();
                    continue;
                }

                Console.Write("Количество: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
                {
                    Console.WriteLine("Неверное количество.");
                    Console.ReadLine();
                    continue;
                }

                if (quantity > item.Quantity)
                {
                    Console.WriteLine($"⚠️  Недостаточно товара. В наличии: {item.Quantity}");
                    Console.ReadLine();
                    continue;
                }

                var existingItem = order.Items.FirstOrDefault(oi => oi.Product.Id == menuId);
                if (existingItem != null)
                {
                    existingItem.Quantity += quantity;
                    existingItem.Subtotal = existingItem.Quantity * item.Price;
                }
                else
                {
                    order.Items.Add(new OrderItem
                    {
                        Product = item,
                        Quantity = quantity,
                        Subtotal = quantity * item.Price
                    });
                }

                item.Quantity -= quantity;
                Console.WriteLine($"✓ {item.Name} добавлен в заказ.");
                Console.ReadLine();
            }

            Console.WriteLine("\nДоступные методы оплаты:");
            Console.WriteLine("1. Наличные");
            Console.WriteLine("2. Карта");
            Console.WriteLine("3. Электронный кошелек");
            Console.Write("Выберите метод (1-3): ");

            order.PaymentMethod = Console.ReadLine() switch
            {
                "1" => "Наличные",
                "2" => "Карта",
                "3" => "Электронный кошелек",
                _ => "Наличные"
            };

            order.TotalAmount = order.Items.Sum(oi => oi.Subtotal);
            orders.Add(order);

            Console.WriteLine($"\n✓ Заказ #{order.Id} создан успешно!");
            Console.WriteLine($"Сумма: {order.TotalAmount:C}");
            Console.ReadLine();
        }

        private void ViewAllOrders()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("                            ВСЕ ЗАКАЗЫ");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine();

            if (orders.Count == 0)
            {
                Console.WriteLine("Заказов нет.");
            }
            else
            {
                foreach (var order in orders)
                {
                    Console.WriteLine(order);
                }
            }

            Console.WriteLine("\nНажмите Enter для продолжения...");
            Console.ReadLine();
        }

        private void ViewOrderDetails()
        {
            Console.Write("Введите ID заказа: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Неверный ID.");
                Console.ReadLine();
                return;
            }

            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                Console.WriteLine("Заказ не найден.");
                Console.ReadLine();
                return;
            }

            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine($"                        ДЕТАЛИ ЗАКАЗА #{order.Id}");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine();
            Console.WriteLine($"Дата: {order.OrderDate:dd.MM.yyyy HH:mm:ss}");
            Console.WriteLine($"Метод оплаты: {order.PaymentMethod}");
            Console.WriteLine();
            Console.WriteLine("Товары:");
            foreach (var item in order.Items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', 87));
            Console.WriteLine($"ИТОГО: {order.TotalAmount,80:C}");

            Console.WriteLine("\nНажмите Enter для продолжения...");
            Console.ReadLine();
        }

        // Управление сотрудниками
        private void EmployeeManagement()
        {
            bool managing = true;
            while (managing)
            {
                Console.Clear();
                Console.WriteLine("═══════════════════════════════════════════════════════");
                Console.WriteLine("            УПРАВЛЕНИЕ СОТРУДНИКАМИ");
                Console.WriteLine("═══════════════════════════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine("1. Просмотреть всех сотрудников");
                Console.WriteLine("2. Добавить сотрудника");
                Console.WriteLine("3. Обновить данные сотрудника");
                Console.WriteLine("4. Удалить сотрудника");
                Console.WriteLine("5. Вернуться в главное меню");
                Console.WriteLine();
                Console.Write("Выберите действие (1-5): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ViewAllEmployees();
                        break;
                    case "2":
                        AddEmployee();
                        break;
                    case "3":
                        UpdateEmployee();
                        break;
                    case "4":
                        DeleteEmployee();
                        break;
                    case "5":
                        managing = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void ViewAllEmployees()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("                         ВСЕ СОТРУДНИКИ");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine();

            if (employees.Count == 0)
            {
                Console.WriteLine("Сотрудников нет.");
            }
            else
            {
                foreach (var emp in employees)
                {
                    Console.WriteLine(emp);
                }

                decimal totalSalaries = employees.Sum(e => e.Salary);
                Console.WriteLine();
                Console.WriteLine($"Всего сотрудников: {employees.Count}");
                Console.WriteLine($"Общий фонд зарплаты: {totalSalaries:C}");
            }

            Console.WriteLine("\nНажмите Enter для продолжения...");
            Console.ReadLine();
        }

        private void AddEmployee()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════");
            Console.WriteLine("                    ДОБАВИТЬ СОТРУДНИКА");
            Console.WriteLine("═══════════════════════════════════════════════════════");
            Console.WriteLine();

            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("ФИО не может быть пустым.");
                Console.ReadLine();
                return;
            }

            Console.Write("Введите должность: ");
            string position = Console.ReadLine();

            Console.Write("Введите телефон: ");
            string phone = Console.ReadLine();

            Console.Write("Введите зарплату: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal salary) || salary < 0)
            {
                Console.WriteLine("Неверная зарплата.");
                Console.ReadLine();
                return;
            }

            employees.Add(new Employee
            {
                Id = nextEmployeeId++,
                Name = name,
                Position = position,
                Phone = phone,
                Salary = salary,
                HireDate = DateTime.Now
            });

            Console.WriteLine($"\n✓ Сотрудник '{name}' успешно добавлен.");
            Console.ReadLine();
        }

        private void UpdateEmployee()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════");
            Console.WriteLine("                  ОБНОВИТЬ ДАННЫЕ СОТРУДНИКА");
            Console.WriteLine("═══════════════════════════════════════════════════════");
            Console.WriteLine();

            Console.Write("Введите ID сотрудника: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Неверный ID.");
                Console.ReadLine();
                return;
            }

            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
            {
                Console.WriteLine("Сотрудник не найден.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"\nТекущие данные: {emp}");
            Console.WriteLine();

            Console.Write("Введите новое ФИО (Enter для пропуска): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                emp.Name = name;

            Console.Write("Введите новую должность (Enter для пропуска): ");
            string position = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(position))
                emp.Position = position;

            Console.Write("Введите новый телефон (Enter для пропуска): ");
            string phone = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(phone))
                emp.Phone = phone;

            Console.Write("Введите новую зарплату (Enter для пропуска): ");
            string salaryInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(salaryInput) && decimal.TryParse(salaryInput, out decimal salary))
                emp.Salary = salary;

            Console.WriteLine($"\n✓ Данные сотрудника успешно обновлены.");
            Console.ReadLine();
        }

        private void DeleteEmployee()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════");
            Console.WriteLine("                    УДАЛИТЬ СОТРУДНИКА");
            Console.WriteLine("═══════════════════════════════════════════════════════");
            Console.WriteLine();

            Console.Write("Введите ID сотрудника: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Неверный ID.");
                Console.ReadLine();
                return;
            }

            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
            {
                Console.WriteLine("Сотрудник не найден.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"\nВы уверены, что хотите удалить '{emp.Name}'? (д/н): ");
            if (Console.ReadLine().ToLower() == "д")
            {
                employees.Remove(emp);
                Console.WriteLine("✓ Сотрудник удалён.");
            }
            else
            {
                Console.WriteLine("✗ Удаление отменено.");
            }
            Console.ReadLine();
        }

        // Отчёты и статистика
        private void Reports()
        {
            bool viewing = true;
            while (viewing)
            {
                Console.Clear();
                Console.WriteLine("═══════════════════════════════════════════════════════");
                Console.WriteLine("            ОТЧЁТЫ И СТАТИСТИКА");
                Console.WriteLine("═══════════════════════════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine("1. Отчёт по продажам");
                Console.WriteLine("2. Отчёт по товарам");
                Console.WriteLine("3. Отчёт по сотрудникам");
                Console.WriteLine("4. Финансовый отчёт");
                Console.WriteLine("5. Вернуться в главное меню");
                Console.WriteLine();
                Console.Write("Выберите отчёт (1-5): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        SalesReport();
                        break;
                    case "2":
                        InventoryReport();
                        break;
                    case "3":
                        EmployeeReport();
                        break;
                    case "4":
                        FinancialReport();
                        break;
                    case "5":
                        viewing = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void SalesReport()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("                         ОТЧЁТ ПО ПРОДАЖАМ");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine();

            if (orders.Count == 0)
            {
                Console.WriteLine("Заказов нет.");
            }
            else
            {
                var totalRevenue = orders.Sum(o => o.TotalAmount);
                var totalOrders = orders.Count;
                var averageOrderSize = totalRevenue / totalOrders;

                Console.WriteLine($"Всего заказов: {totalOrders}");
                Console.WriteLine($"Общая выручка: {totalRevenue:C}");
                Console.WriteLine($"Средний размер заказа: {averageOrderSize:C}");
                Console.WriteLine();

                Console.WriteLine("Продажи по методам оплаты:");
                var paymentGroups = orders.GroupBy(o => o.PaymentMethod);
                foreach (var group in paymentGroups)
                {
                    var count = group.Count();
                    var amount = group.Sum(o => o.TotalAmount);
                    Console.WriteLine($"  {group.Key,-25} Заказов: {count,3} | Сумма: {amount,12:C}");
                }

                Console.WriteLine();
                Console.WriteLine("Популярные товары:");
                var topProducts = new Dictionary<string, (int quantity, decimal amount)>();
                foreach (var order in orders)
                {
                    foreach (var item in order.Items)
                    {
                        if (topProducts.ContainsKey(item.Product.Name))
                        {
                            var existing = topProducts[item.Product.Name];
                            topProducts[item.Product.Name] = (existing.quantity + item.Quantity, existing.amount + item.Subtotal);
                        }
                        else
                        {
                            topProducts[item.Product.Name] = (item.Quantity, item.Subtotal);
                        }
                    }
                }

                foreach (var product in topProducts.OrderByDescending(p => p.Value.quantity).Take(5))
                {
                    Console.WriteLine($"  {product.Key,-20} Продано: {product.Value.quantity,3} | На сумму: {product.Value.amount,10:C}");
                }
            }

            Console.WriteLine("\nНажмите Enter для продолжения...");
            Console.ReadLine();
        }

        private void InventoryReport()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("                         ОТЧЁТ ПО ТОВАРАМ");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine();

            if (menuItems.Count == 0)
            {
                Console.WriteLine("Товаров нет.");
            }
            else
            {
                decimal totalValue = 0;
                foreach (var item in menuItems)
                {
                    var itemValue = item.Price * item.Quantity;
                    totalValue += itemValue;
                }

                Console.WriteLine($"Всего товаров в каталоге: {menuItems.Count}");
                Console.WriteLine($"Общая стоимость запасов: {totalValue:C}");
                Console.WriteLine();

                Console.WriteLine("Товары по категориям:");
                var grouped = menuItems.GroupBy(m => m.Category);
                foreach (var group in grouped)
                {
                    var categoryValue = group.Sum(m => m.Price * m.Quantity);
                    var totalQuantity = group.Sum(m => m.Quantity);
                    Console.WriteLine($"\n📁 {group.Key}:");
                    foreach (var item in group)
                    {
                        var itemValue = item.Price * item.Quantity;
                        Console.WriteLine($"   {item.Name,-20} Кол-во: {item.Quantity,3} | Цена: {item.Price,8:C} | Стоимость: {itemValue,10:C}");
                    }
                    Console.WriteLine($"   Итого в категории: {categoryValue,34:C}");
                }

                Console.WriteLine();
                Console.WriteLine("Товары с низким запасом (< 30):");
                var lowStock = menuItems.Where(m => m.Quantity < 30).OrderBy(m => m.Quantity);
                if (lowStock.Count() == 0)
                {
                    Console.WriteLine("  Все товары в нормальном количестве.");
                }
                else
                {
                    foreach (var item in lowStock)
                    {
                        Console.WriteLine($"  ⚠️  {item.Name,-20} Кол-во: {item.Quantity,3}");
                    }
                }
            }

            Console.WriteLine("\nНажмите Enter для продолжения...");
            Console.ReadLine();
        }

        private void EmployeeReport()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("                      ОТЧЁТ ПО СОТРУДНИКАМ");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine();

            if (employees.Count == 0)
            {
                Console.WriteLine("Сотрудников нет.");
            }
            else
            {
                decimal totalSalaries = employees.Sum(e => e.Salary);
                decimal averageSalary = totalSalaries / employees.Count;

                Console.WriteLine($"Всего сотрудников: {employees.Count}");
                Console.WriteLine($"Общий фонд зарплаты: {totalSalaries:C}");
                Console.WriteLine($"Средняя зарплата: {averageSalary:C}");
                Console.WriteLine();

                Console.WriteLine("Сотрудники по должностям:");
                var grouped = employees.GroupBy(e => e.Position);
                foreach (var group in grouped)
                {
                    var positionSalaries = group.Sum(e => e.Salary);
                    Console.WriteLine($"\n  {group.Key} ({group.Count()} сотр.):");
                    foreach (var emp in group)
                    {
                        Console.WriteLine($"    {emp.Name,-20} Зарплата: {emp.Salary,10:C} | На работе с: {emp.HireDate:dd.MM.yyyy}");
                    }
                    Console.WriteLine($"    Итого: {positionSalaries,55:C}");
                }

                Console.WriteLine();
                Console.WriteLine("Самые новые сотрудники:");
                foreach (var emp in employees.OrderByDescending(e => e.HireDate).Take(3))
                {
                    var daysWorked = (DateTime.Now - emp.HireDate).Days;
                    Console.WriteLine($"  {emp.Name,-20} Должность: {emp.Position,-15} (работает {daysWorked} дней)");
                }
            }

            Console.WriteLine("\nНажмите Enter для продолжения...");
            Console.ReadLine();
        }

        private void FinancialReport()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("                       ФИНАНСОВЫЙ ОТЧЁТ");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine();

            decimal totalRevenue = orders.Sum(o => o.TotalAmount);
            decimal totalSalaries = employees.Sum(e => e.Salary);
            decimal inventoryValue = menuItems.Sum(m => m.Price * m.Quantity);

            Console.WriteLine("📊 ОСНОВНЫЕ ПОКАЗАТЕЛИ:");
            Console.WriteLine();
            Console.WriteLine($"  Выручка от продаж:         {totalRevenue,40:C}");
            Console.WriteLine($"  Затраты на зарплату:       {totalSalaries,40:C}");
            Console.WriteLine($"  Стоимость запасов:         {inventoryValue,40:C}");
            Console.WriteLine();

            if (totalRevenue > 0)
            {
                decimal profitMargin = ((totalRevenue - totalSalaries) / totalRevenue) * 100;
                Console.WriteLine($"  Потенциальная прибыль:     {(totalRevenue - totalSalaries),40:C}");
                Console.WriteLine($"  Маржа прибыли:            {profitMargin,39:F2}%");
            }

            Console.WriteLine();
            Console.WriteLine("📈 СРЕДНИЕ ПОКАЗАТЕЛИ:");
            Console.WriteLine();
            if (orders.Count > 0)
            {
                Console.WriteLine($"  Средний размер заказа:     {(totalRevenue / orders.Count),40:C}");
                Console.WriteLine($"  Всего заказов:             {orders.Count,40:D}");
            }

            if (employees.Count > 0)
            {
                Console.WriteLine($"  Средняя зарплата сотр.:    {(totalSalaries / employees.Count),40:C}");
            }

            Console.WriteLine();
            Console.WriteLine("💰 АНАЛИЗ:");
            Console.WriteLine();

            if (menuItems.Count > 0)
            {
                var costOfGoods = menuItems.Sum(m => m.Price * m.Quantity);
                Console.WriteLine($"  Инвестировано в товары:    {costOfGoods,40:C}");
            }

            var lowStockValue = menuItems.Where(m => m.Quantity < 30).Sum(m => m.Price * m.Quantity);
            if (lowStockValue > 0)
            {
                Console.WriteLine($"  Стоимость низких запасов:  {lowStockValue,40:C}");
            }

            Console.WriteLine("\nНажмите Enter для продолжения...");
            Console.ReadLine();
        }
    }

    // Точка входа программы
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var system = new CafeAccountingSystem();
            system.Run();
        }
    }
}
