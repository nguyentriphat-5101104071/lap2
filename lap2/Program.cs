using System;
using System.Text;

namespace Lab02_QuanLyMang
{
    class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập font hiển thị tiếng Việt có dấu tốt hơn trên Console
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            int[] mang = null; // Khởi tạo mảng ban đầu bằng null để kiểm tra xem mảng đã được nhập chưa
            int luaChon = -1;

            do
            {
                XuatMenu();
                luaChon = NhapSoNguyen("Chọn chức năng: ");
                Console.WriteLine();

                switch (luaChon)
                {
                    case 1:
                        mang = NhapMang();
                        break;
                    case 2:
                        if (KiemTraMangChuaNhap(mang))
                        {
                            Console.Write("Mảng hiện tại: ");
                            XuatMang(mang);
                        }
                        break;
                    case 3:
                        if (KiemTraMangChuaNhap(mang))
                        {
                            int tong = TinhTong(mang);
                            Console.WriteLine($"Tổng các phần tử trong mảng là: {tong}");
                        }
                        break;
                    case 4:
                        if (KiemTraMangChuaNhap(mang))
                        {
                            int max = TimMax(mang);
                            int min = TimMin(mang);
                            Console.WriteLine($"Giá trị lớn nhất (Max): {max}");
                            Console.WriteLine($"Giá trị nhỏ nhất (Min): {min}");
                        }
                        break;
                    case 5:
                        if (KiemTraMangChuaNhap(mang))
                        {
                            int chan = DemChan(mang);
                            int le = DemLe(mang);
                            Console.WriteLine($"Số lượng phần tử chẵn: {chan}");
                            Console.WriteLine($"Số lượng phần tử lẻ: {le}");
                        }
                        break;
                    case 6:
                        if (KiemTraMangChuaNhap(mang))
                        {
                            // Tạo một bản sao để sắp xếp, tránh làm thay đổi mảng gốc ban đầu (nếu muốn giữ mảng gốc)
                            int[] mangSapXep = (int[])mang.Clone();
                            SapXepTangDan(mangSapXep);
                            Console.Write("Mảng sau khi sắp xếp tăng dần: ");
                            XuatMang(mangSapXep);
                        }
                        break;
                    case 7:
                        if (KiemTraMangChuaNhap(mang))
                        {
                            int x = NhapSoNguyen("Nhập giá trị x cần tìm: ");
                            int viTri = TimKiem(mang, x);
                            if (viTri != -1)
                            {
                                Console.WriteLine($"Tìm thấy {x} tại vị trí đầu tiên trong mảng là: {viTri} (tính từ 0).");
                            }
                            else
                            {
                                Console.WriteLine($"Không tìm thấy {x} trong mảng.");
                            }
                        }
                        break;
                    case 0:
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình. Tạm biệt!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ! Vui lòng chọn lại từ 0 đến 7.");
                        break;
                }

                if (luaChon != 0)
                {
                    Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                    Console.ReadKey();
                }

            } while (luaChon != 0);
        }

        // --- CÁC PHƯƠNG THỨC TRỢ GIÚP ---

        // Hiển thị Menu
        static void XuatMenu()
        {
            Console.Clear();
            Console.WriteLine("===== MENU =====");
            Console.WriteLine("1. Nhap mang");
            Console.WriteLine("2. Xuat mang");
            Console.WriteLine("3. Tinh tong");
            Console.WriteLine("4. Tim max/min");
            Console.WriteLine("5. Dem chan/le");
            Console.WriteLine("6. Sap xep tang dan");
            Console.WriteLine("7. Tim kiem");
            Console.WriteLine("0. Thoat");
        }

        // Nhập số nguyên thông thường (có kiểm tra lỗi nhập chữ)
        static int NhapSoNguyen(string message)
        {
            int giaTri;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out giaTri))
                {
                    return giaTri;
                }
                Console.WriteLine("Lỗi: Vui lòng nhập một số nguyên hợp lệ!");
            }
        }

        // Nhập số nguyên dương (áp dụng cho n - số phần tử mảng)
        static int NhapSoNguyenDuong(string message)
        {
            int giaTri;
            while (true)
            {
                giaTri = NhapSoNguyen(message);
                if (giaTri > 0)
                {
                    return giaTri;
                }
                Console.WriteLine("Lỗi: Số lượng phần tử phải là số nguyên dương lớn hơn 0!");
            }
        }

        // Kiểm tra xem người dùng đã thực hiện nhập mảng hay chưa trước khi xử lý
        static bool KiemTraMangChuaNhap(int[] a)
        {
            if (a == null)
            {
                Console.WriteLine("Lỗi: Bạn phải nhập mảng trước khi thực hiện chức năng này (Chọn chức năng 1)!");
                return false;
            }
            return true;
        }

        // --- CÁC PHƯƠNG THỨC XỬ LÝ MẢNG CHÍNH ---

        // 1. Nhập mảng
        static int[] NhapMang()
        {
            int n = NhapSoNguyenDuong("Nhập số lượng phần tử n: ");
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = NhapSoNguyen($"Nhập phần tử a[{i}]: ");
            }
            Console.WriteLine("Nhập mảng thành công!");
            return a;
        }

        // 2. Xuất mảng
        static void XuatMang(int[] a)
        {
            if (a.Length == 0)
            {
                Console.WriteLine("Mảng trống.");
                return;
            }
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }

        // 3. Tính tổng mảng
        static int TinhTong(int[] a)
        {
            int tong = 0;
            foreach (int item in a)
            {
                tong += item;
            }
            return tong;
        }

        // 4. Tìm phần tử lớn nhất (Max)
        static int TimMax(int[] a)
        {
            int max = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
            }
            return max;
        }

        // 4. Tìm phần tử nhỏ nhất (Min)
        static int TimMin(int[] a)
        {
            int min = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                }
            }
            return min;
        }

        // 5. Đếm số phần tử chẵn
        static int DemChan(int[] a)
        {
            int dem = 0;
            foreach (int item in a)
            {
                if (item % 2 == 0)
                {
                    dem++;
                }
            }
            return dem;
        }

        // 5. Đếm số phần tử lẻ
        static int DemLe(int[] a)
        {
            int dem = 0;
            foreach (int item in a)
            {
                if (item % 2 != 0)
                {
                    dem++;
                }
            }
            return dem;
        }

        // 6. Sắp xếp mảng tăng dần (sử dụng thuật toán Bubble Sort đơn giản hoặc Array.Sort)
        static void SapXepTangDan(int[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        // Hoán vị
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
            }
        }

        // 7. Tìm kiếm phần tử x trong mảng, trả về vị trí đầu tiên hoặc -1 nếu không thấy
        static int TimKiem(int[] a, int x)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == x)
                {
                    return i; // Trả về chỉ số vị trí tìm thấy đầu tiên
                }
            }
            return -1; // Không tìm thấy
        }
    }
}
