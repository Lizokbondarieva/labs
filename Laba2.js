// Створення масиву для зберігання даних
var students = [];

// Функція для додавання студента
function addStudent() {
    var name = prompt("Введіть ПІБ студента");
    var grade = prompt("Введіть оцінку студента");
    // Перевірка, чи введені дані не пусті та оцінка є числом
    if (name && !isNaN(grade)) {
        students.push({ name: name.trim(), grade: parseInt(grade) });
    } else {
        alert("Введені дані некоректні. Перевірте введені значення.");
    }
}

// Функція для виведення журналу на екран
function displayGrades() {
    document.write("<table>");
    document.write("<tr><th>ПІБ</th><th>Оцінка</th></tr>");
   
    students.forEach(function(student) {
        document.write("<tr><td>" + student.name + "</td><td>" + student.grade + "</td></tr>");
    });
    
    document.write("</table>");
}

// Функція для отримання оцінки за прізвищем
function getGradeByName() {
    var name = prompt("Введіть ПІБ студента");
    var found = false;
    students.forEach(function(student) {
        if (student.name === name.trim()) {
            alert(`Оцінка ${name}: ${student.grade}`);
            found = true;
        }
    });
    if (!found) {
        alert("Студент не знайдений");
    }
}

// Головна функція
function main() {
    var choice = 0;
    while (choice !== 4) {
        choice = parseInt(prompt("1. Додати студента\n2. Вивести журнал\n3. Отримати оцінку за прізвищем\n4. Вийти"));
        switch (choice) {
            case 1:
                addStudent();
                break;
            case 2:
                displayGrades();
                break;
            case 3:
                getGradeByName();
                break;
            case 4:
                break;
            default:
                alert("Неправильний вибір");
        }
    }
}

// Виклик головної функції
main();
