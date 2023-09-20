using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitap1._14
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int[] pages = new int[12];
            Console.WriteLine("Người dùng hãy tự nhập các trang: ");
            Console.WriteLine("Gợi ý: pages = { 205, 135, 80, 90, 70, 110, 60, 85, 200, 140, 170, 120 }\n");
            for (int i = 0; i < pages.Length; i++)
            {
                Console.Write($"Nhập số trang luận văn Q{i + 1}: ");
                pages[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Dữ liệu đã nhận, sau đây là các trang bạn đã nhập: \n");
            for (int i = 0; i < pages.Length; i++)
            {
                Console.WriteLine($"Trang {i + 1}: {pages[i]} trang");
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------------------------------------------------------------");
            int numEmployees;
            Console.WriteLine("Nhập số nhân viên với hiệu suất đánh máy của mỗi nhân viên là 8 trang 1 giờ(3): ");
            numEmployees = int.Parse(Console.ReadLine());
            int pagesPerHourPerEmployee = 8;
            Console.WriteLine("Phần a:");
            AssignPagesToEmployees(pages, numEmployees, pagesPerHourPerEmployee);

            int numManagers = 1; Console.WriteLine("\n\nThêm 1 quản lý có hiệu suất đánh máy là 4 trang 1 giờ thì: ");
            int pagesPerHourPerManager = 4;
            Console.WriteLine("Phần b:");
            AssignPagesToEmployeesAndManager(pages, numEmployees, pagesPerHourPerEmployee, numManagers, pagesPerHourPerManager);




            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("\n\n\nLưu ý: -Bài toán được giải theo thuật toán tham lam(greedy algorithm) và thời gian đã được làm tròn theo đơn vị giờ");
            Console.ReadLine();
        }

        static void AssignPagesToEmployees(int[] pages, int numEmployees, int pagesPerHourPerEmployee)
        {
            int[] assignment = new int[numEmployees]; // Mảng ghi lại việc phân công
            string[] employeeNames = { "Nhân viên 1", "Nhân viên 2", "Nhân viên 3" };

            // Sắp xếp các luận văn theo số trang giảm dần
            Array.Sort(pages, (a, b) => -a.CompareTo(b));

            for (int i = 0; i < pages.Length; i++)
            {
                int minLoad = assignment.Min(); // Tìm công việc có tải nhẹ nhất
                int minLoadIndex = Array.IndexOf(assignment, minLoad);

                // Gán luận văn có số trang lớn nhất cho người có tải nhẹ nhất
                assignment[minLoadIndex] += pages[i];
                Console.WriteLine($"{employeeNames[minLoadIndex]} đánh {pages[i]} trang của luận văn Q{i + 1}");
            }
        }

        static void AssignPagesToEmployeesAndManager(int[] pages, int numEmployees, int pagesPerHourPerEmployee, int numManagers, int pagesPerHourPerManager)
        {
            int[] assignment = new int[numEmployees + numManagers]; // Mảng ghi lại việc phân công
            string[] names = { "Nhân viên 1", "Nhân viên 2", "Nhân viên 3", "Quản lý" };

            // Sắp xếp các luận văn theo số trang giảm dần
            Array.Sort(pages, (a, b) => -a.CompareTo(b));

            for (int i = 0; i < pages.Length; i++)
            {
                int minLoad = assignment.Min(); // Tìm công việc có tải nhẹ nhất
                int minLoadIndex = Array.IndexOf(assignment, minLoad);

                // Gán luận văn có số trang lớn nhất cho người có tải nhẹ nhất
                assignment[minLoadIndex] += pages[i];
                Console.WriteLine($"{names[minLoadIndex]} đánh {pages[i]} trang của luận văn Q{i + 1}");
            }
        }
    }
}
