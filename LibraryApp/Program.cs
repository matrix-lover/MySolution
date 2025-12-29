using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddRazorPages();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Urls.Add("http://localhost:5000");
app.Urls.Add("https://localhost:5001");

Console.WriteLine("Application is running on:");
foreach (var url in app.Urls)
{
    Console.WriteLine(url);
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LibraryContext>();

    db.Database.Migrate();

    if (!db.Students.Any())
    {
        var s1 = new Student { FullName = "Иван Иванов" };
        var s2 = new Student { FullName = "Мария Петрова" };
        db.Students.AddRange(s1, s2);

        var subj1 = new Subject { Name = "Математика" };
        var subj2 = new Subject { Name = "Физика" };
        db.Subjects.AddRange(subj1, subj2);

        db.SaveChanges();

        db.ExamResults.AddRange(
            new ExamResult { StudentId = s1.Id, SubjectId = subj1.Id, Score = 85 },
            new ExamResult { StudentId = s1.Id, SubjectId = subj2.Id, Score = 90 },
            new ExamResult { StudentId = s2.Id, SubjectId = subj1.Id, Score = 78 },
            new ExamResult { StudentId = s2.Id, SubjectId = subj2.Id, Score = 88 }
        );

        db.SaveChanges();
    }
}

app.Run();
