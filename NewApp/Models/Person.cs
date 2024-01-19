namespace NewApp.Models
{
    public class Person
    {
        public Person(){
            FullName = "Nguyễn Khánh Linh";
            Address = "Thanh Hoá";
            Age = 22;
        }
        public string FullName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public void  EnterData(){
            System.Console.WriteLine("Enter your name: ");
            FullName = System.Console.ReadLine();
            System.Console.WriteLine("Enter your address: ");
            Address = System.Console.ReadLine();
            System.Console.WriteLine("Enter your age: ");
            Age = int.Parse(System.Console.ReadLine());
        }
        public void Display(){
            System.Console.WriteLine("Name: {0}", FullName);
            System.Console.WriteLine("Address: {0}", Address);
            System.Console.WriteLine("Age: {0}", Age);
            try{
                Age = Convert.ToInt16(Console.ReadLine());
            }
            catch(Exception e){
                Age = 0;
            }
        }
        public void Display(string ten, string diaChi, int tuoi){
            System.Console.WriteLine("Name: {0}", ten);
            System.Console.WriteLine("Address: {0}", diaChi);
            System.Console.WriteLine("Age: {0}", tuoi);
        }
        public void Display2(string ten, int tuoi){
            System.Console.WriteLine("Name: {0}", ten);
            System.Console.WriteLine("Age: {0}", tuoi);
        }
        public int GetYearOfBirth(){
            return 2024 - Age;
        }
    }
}