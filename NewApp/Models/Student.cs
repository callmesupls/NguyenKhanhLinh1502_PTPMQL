using System.Security.AccessControl;
namespace NewApp.Models{

    public class Student : Person{
        public string StudentCode { get; set; }
        public void EnterData(){
            base.EnterData();
            System.Console.WriteLine("Enter your student code: ");
            StudentCode = Console.ReadLine();
        }
        public void Display(){
            base.Display();
            System.Console.WriteLine("Student code: {0}", StudentCode);
        }
    }
}