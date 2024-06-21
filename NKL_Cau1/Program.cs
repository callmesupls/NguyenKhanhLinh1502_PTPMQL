using System;

class Program
{
    // Hàm tính giai thừa của một số nguyên dương
    static long TinhGiaiThua(int n)
    {
        if (n == 0 || n == 1)
            return 1;
        
        long giaiThua = 1;
        for (int i = 2; i <= n; i++)
        {
            giaiThua *= i;
        }
        return giaiThua;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Nhap so nguyen duong n de tinh giai thua:");
        int n = int.Parse(Console.ReadLine());

        if (n < 0)
        {
            Console.WriteLine("Khong tinh đuoc giai thua cua so am.");
        }
        else
        {
            long ketQua = TinhGiaiThua(n);
            Console.WriteLine($"Giai thua cua {n} la: {ketQua}");
        }
    }
}
