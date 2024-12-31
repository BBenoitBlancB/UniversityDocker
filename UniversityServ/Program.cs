using UniversityTDD;

ScheduleManager scheduleManager = new ScheduleManager();

// Створення класів
ClassSession mathClass = new ClassSession("Математика", "Іваненко І.", "Аудиторія 101", new DateTime(2024, 1, 2, 9, 0, 0), new DateTime(2024, 1, 2, 10, 30, 0));
ClassSession physicsClass = new ClassSession("Фізика", "Петренко П.", "Аудиторія 102", new DateTime(2024, 1, 2, 11, 0, 0), new DateTime(2024, 1, 2, 12, 30, 0));
ClassSession chemistryClass = new ClassSession("Хімія", "Сидоренко С.", "Аудиторія 103", new DateTime(2024, 1, 2, 10, 0, 0), new DateTime(2024, 1, 2, 11, 30, 0)); // Конфлікт

// Додавання класів до розкладу
try
{
    scheduleManager.AddClass("Група А", mathClass);
    scheduleManager.AddClass("Група А", physicsClass);
    scheduleManager.AddClass("Група А", chemistryClass); // Це викличе виняток
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Помилка: {ex.Message}");
}

// Виведення розкладу для групи А
Console.WriteLine("Розклад для Групи А:");
List<ClassSession> groupClasses = scheduleManager.GetClassesForGroup("Група А");
foreach (var classSession in groupClasses)
{
    Console.WriteLine($"{classSession.Subject} - {classSession.Teacher}, {classSession.Room}, {classSession.StartTime} - {classSession.EndTime}");
}

// Видалення заняття
try
{
    scheduleManager.RemoveClass("Група А", "Математика");
    Console.WriteLine("\nЗаняття 'Математика' видалено.");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Помилка: {ex.Message}");
}

// Виведення оновленого розкладу
Console.WriteLine("\nОновлений розклад для Групи А:");
groupClasses = scheduleManager.GetClassesForGroup("Група А");
foreach (var classSession in groupClasses)
{
    Console.WriteLine($"{classSession.Subject} - {classSession.Teacher}, {classSession.Room}, {classSession.StartTime} - {classSession.EndTime}");
}