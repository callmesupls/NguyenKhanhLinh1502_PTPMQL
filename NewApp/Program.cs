using NewApp.Models;
public class Program{
    private static void Main(string[] args){
        Person person1 = new Person();
        Person person2 = new Person();
        person1.FullName = "Nguyễn Khánh Linh";
        person1.Address = "Thanh Hoá";
        person1.Age = 22;
        person1.Display();
        person2.Display();

        ////////////////
        
        Person person = new Person();
        string str = "Nguyễn Khánh Linh";
        int age = 22;
        person.Display2(str, age);
        Console.WriteLine(str,", Year of birth: {0}", person.GetYearOfBirth());

        ////////////////
        
        Student std = new Student();
        std.EnterData();
        std.Display();
    }
}