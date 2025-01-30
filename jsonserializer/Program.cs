using assignment_1;
using System.Reflection;
using System.Text;

Course course = new Course();
course.Title = "Asp.net";
course.Fees = 30000;
course.Gender = new Gender
{
    IsMale = true
};
course.Teacher = new Instructor()
{
    Name = "Jalaluddin",
    Email = "jalal@gmail.com",
    PresentAddress = new Address()
    {
        Street = "Senpara1",
        City = "Dhaka",
        Country = "Bangladesh"
    },
    PermanentAddress = new Address()
    {
        Street = "Senpara1",
        City = "Dhaka",
        Country = "Bangladesh"
    },
    PhoneNumbers = new List<Phone>
    {
        new Phone()
        {
            Number = "12345678910",
            Extension = "141",
            CountryCode = "+880"
        },
        new Phone()
        {
            Number = "42111145678910",
            Extension = "151",
            CountryCode = "+880"
        },
        new Phone()
        {
            Number = "151545678910",
            Extension = "171",
            CountryCode = "+880"
        }
    }
    
};
course.Topics = new List<Topic>
{
    new Topic()
    {
        Title = "Asp.net",
        Description = "Asp.net core MVC",
        Sessions = new List<Session>
        {
            new Session()
            {
                DurationInHour = 400,
                LearningObjective = "To Help Undrstand ASP.net core MVC"
            }
        }
    }
};
course.Tests = new List<AdmissionTest>
{
    new AdmissionTest()
    {
        StartDateTime = DateTime.Now,
        EndDateTime = DateTime.Now,
        TestFees = 100
    }
};

string txt = JsonFormatter.Convert(course);
Console.WriteLine(txt);