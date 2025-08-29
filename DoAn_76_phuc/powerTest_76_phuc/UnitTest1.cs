using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DoAn_76_phuc;

namespace powerTest_76_phuc
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }//tạo đối tượng TestContext dùng để đọc dữ liệu
        [TestMethod]
        public void TC1_xLonHon0_76_phuc()//test case với x và n là số nguyên dương
        {
            int n_76_phuc;
            double actual_76_phuc;
            double x_76_phuc, expected_76_phuc;
            n_76_phuc = 2;
            x_76_phuc = 2;
            expected_76_phuc = 4;// kết quả mong muốn
            actual_76_phuc = Power.power_76_phuc(x_76_phuc, n_76_phuc);// kết quả thực tế
            Assert.AreEqual(expected_76_phuc, actual_76_phuc);// so sánh kết quả mong muốn và kết quả thực tế
        }

        [TestMethod]
        public void TC2_xNhoHon0_76_phuc()//test case với x là số nguyên âm n là số bất kì
        {
            int n_76_phuc;
            double actual_76_phuc;
            double x_76_phuc, expected_76_phuc;
            n_76_phuc = 4;
            x_76_phuc = -3;
            expected_76_phuc = 81;
            actual_76_phuc = Power.power_76_phuc(x_76_phuc, n_76_phuc);
            Assert.AreEqual(expected_76_phuc, actual_76_phuc);
        }

        [TestMethod]
        public void TC3_nBang0_76_phuc()//với số mũ bằng 0,x là số bất kì 
        {
            int n_76_phuc;
            double actual_76_phuc;
            double x_76_phuc, expected_76_phuc;
            n_76_phuc = 0;
            x_76_phuc = -3;
            expected_76_phuc = 1;
            actual_76_phuc = Power.power_76_phuc(x_76_phuc, n_76_phuc);
            Assert.AreEqual(expected_76_phuc, actual_76_phuc);
        }

        [TestMethod]
        public void TC4_nNhoHon0_76_phuc()//với n âm, x là số bất kì 
        {
            int n_76_phuc;
            double actual_76_phuc;
            double x_76_phuc, expected_76_phuc;
            n_76_phuc = -2;
            x_76_phuc = 5;
            expected_76_phuc = 0.04;
            actual_76_phuc = Power.power_76_phuc(x_76_phuc, n_76_phuc);
            Assert.AreEqual(expected_76_phuc, actual_76_phuc);
        }

        [TestMethod]
        public void TC5_xBang0_76_phuc()//với x = 0, n là số bất kì
        {
            int n_76_phuc;
            double actual_76_phuc;
            double x_76_phuc, expected_76_phuc;
            n_76_phuc = 4;
            x_76_phuc = 0;
            expected_76_phuc = 0;
            actual_76_phuc = Power.power_76_phuc(x_76_phuc, n_76_phuc);
            Assert.AreEqual(expected_76_phuc, actual_76_phuc);
        }

        [TestMethod]
        public void TC6_xLaSoThuc_76_phuc()//với x là số thực, n là số bất kì 
        {
            int n_76_phuc;
            double actual_76_phuc;
            double x_76_phuc, expected_76_phuc;
            n_76_phuc = 2;
            x_76_phuc = 2.5;
            expected_76_phuc = 6.25;
            actual_76_phuc = Power.power_76_phuc(x_76_phuc, n_76_phuc);
            Assert.AreEqual(expected_76_phuc, actual_76_phuc);
        }

        [TestMethod]
        // với x=0, n<0 sẽ không ném ra ngoại lệ vì code sai ở trường hợp 3,trong c# mẫu bằng 0 kết quả sẽ ra vô cực
        [ExpectedException(typeof(DivideByZeroException))]
        public void TC7_xBang0VanNhoHon0_76_phuc()
        {
            Power.power_76_phuc(0, -1);
        }


        //Test với file csv
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\data_76_phuc\testData_76_Phuc.csv", "testData_76_Phuc#csv", DataAccessMethod.Sequential)]//đường dẫn đến data source file csv
        [TestMethod]
        public void TestWithDataSourceCsv_76_Phuc()
        {
            int n_76_phuc;
            double actual_76_phuc;
            double x_76_phuc, expected_76_phuc;
            n_76_phuc = int.Parse(TestContext.DataRow[1].ToString());// lấy giá trị n từ file csv
            x_76_phuc = double.Parse(TestContext.DataRow[0].ToString());//lấy giá trị x từ file csv
            expected_76_phuc = double.Parse(TestContext.DataRow[2].ToString());//lấy kết quả mong muốn từ file csv
            actual_76_phuc = Power.power_76_phuc(x_76_phuc, n_76_phuc);
            Assert.AreEqual(expected_76_phuc, actual_76_phuc);

        }

        //Test với file Excel
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\data_76_phuc\\testData_76_phuc.xlsx;Extended Properties='Excel 12.0 Xml;HDR=YES';", "Sheet1$",
    DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestWithExcelDataSourceXlsx_76_Phuc()
        {
            int n_76_phuc = int.Parse(TestContext.DataRow[1].ToString());
            double x_76_phuc = double.Parse(TestContext.DataRow[0].ToString());
            double expected_76_phuc = double.Parse(TestContext.DataRow[2].ToString());

            double actual_76_phuc = Power.power_76_phuc(x_76_phuc, n_76_phuc);
            Assert.AreEqual(expected_76_phuc, actual_76_phuc);
        }

    }
}
