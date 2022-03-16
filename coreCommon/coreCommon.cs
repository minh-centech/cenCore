using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace coreCommon
{
    public static class coreCommon
    {
        public static string EncryptString(string Message)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            // Buoc 1: Bam chuoi su dung MD5

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(GlobalVariables.EncryptPhase));

            // Step 2. Tao doi tuong TripleDESCryptoServiceProvider moi
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider
            {

                // Step 3. Cai dat bo ma hoa
                Key = TDESKey,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            // Step 4. Convert chuoi (Message) thanh dang byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);

            // Step 5. Ma hoa chuoi
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                //Xoa moi thong tin ve Triple DES va HashProvider de dam bao an toan
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Tra ve chuoi da ma hoa bang thuat toan Base64
            return Convert.ToBase64String(Results);
        }
        public static string DecryptString(string Message)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. Bam chuoi su dung MD5

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(GlobalVariables.EncryptPhase));

            // Step 2. Tao doi tuong TripleDESCryptoServiceProvider moi
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider
            {

                // Step 3. Cai dat bo giai ma
                Key = TDESKey,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            // Step 4. Convert chuoi (Message) thanh dang byte[]
            byte[] DataToDecrypt = Convert.FromBase64String(Message);

            // Step 5. Bat dau giai ma chuoi
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Xoa moi thong tin ve Triple DES va HashProvider de dam bao an toan
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Tra ve ket qua bang dinh dang UTF8
            return UTF8.GetString(Results);
        }
        public static String TraTuDien(String Ma)
        {
            if (Ma == null) return "";
            String rWord = Ma;
            if (GlobalVariables.dtTuDien != null && GlobalVariables.dtTuDien.Rows.Count > 0)
            {
                DataRow[] drTuDien = GlobalVariables.dtTuDien.Select("Ma = '" + Ma + "'");
                if (drTuDien != null && drTuDien.Length > 0)
                    rWord = drTuDien[0]["Ten"].ToString();
            }
            return rWord;
        }
        //Khai báo biến khác
        static readonly string[] strDigit = { "không ", "một ", "hai ", "ba ", "bốn ", "năm ", "sáu ", "bảy ", "tám ", "chín " };
        static readonly string[] strGroup = { "nghìn ", "triệu ", "tỷ " };
        /// <summary>
        /// Đọc group 3 số
        /// </summary>
        /// <param name="iNum">Số cần đọc</param>
        /// <returns></returns>
        private static String Group3(short iNum)
        {
            string iNumStr = null;
            byte[] iDg = new byte[3];
            string[] sResult = new string[3];
            if (iNum == 0)
            {
                return "";
            }
            iNumStr = iNum.ToString();
            while (iNumStr.Length < 3)
            {
                iNumStr = "0" + iNumStr;
            }

            iDg[2] = Convert.ToByte(iNumStr[0].ToString());
            iDg[1] = Convert.ToByte(iNumStr[1].ToString());
            iDg[0] = Convert.ToByte(iNumStr[2].ToString());

            sResult[2] = strDigit[iDg[2]] + "trăm ";
            if (iDg[1] >= 2)
            {
                sResult[1] = strDigit[iDg[1]] + "mươi ";
            }
            else if (iDg[1] == 1)
            {
                sResult[1] = "mười ";
            }
            else if (iDg[1] == 0)
            {
                sResult[1] = "lẻ ";
            }

            sResult[0] = strDigit[iDg[0]];

            if (iDg[0] == 0)
            {
                sResult[0] = "";
                if (iDg[1] == 0)
                {
                    sResult[1] = "";
                }
            }
            else if (iDg[0] == 1 && iDg[1] >= 2)
            {
                sResult[0] = "mốt ";
            }
            else if (iDg[0] == 5 && iDg[1] >= 1)
            {
                sResult[0] = "lăm ";
            }

            return sResult[2] + sResult[1] + sResult[0];
        }
        /// <summary>
        /// Đọc tiền bằng chữ
        /// </summary>
        /// <param name="iNum">Chuỗi tiền</param>
        /// <returns></returns>
        public static String SoTienBangChu(string iNum)
        {
            try
            {
                short iG = 0;
                byte k = 0;
                string st = null;
                string s = "";
                bool negative = false;
                //Xử lí số âm
                if (iNum.StartsWith("-"))
                {
                    negative = true;
                    iNum = iNum.Replace("-", "");
                }

                for (short i = Convert.ToInt16((iNum.Length - 6)); i >= iNum.Length % 3; i += -3)
                {
                    iG = short.Parse(iNum.Substring(i, 3));
                    st = Group3(iG);
                    if (!string.IsNullOrEmpty(st))
                    {
                        st += strGroup[k];
                    }
                    else if (k % 3 == 2)
                    {
                        st = strGroup[k];
                    }
                    k = Convert.ToByte(((k + 1) % 3));
                    s = st + s;
                }
                if (iNum.Length % 3 != 0 && iNum.Length > 3)
                {
                    iG = short.Parse(iNum.Substring(0, iNum.Length % 3));
                    st = Group3(iG);
                    st += strGroup[k];
                    s = st + s;
                }
                s = s + Group3(short.Parse(iNum.Substring(Math.Max(iNum.Length - 3, 0))));
                if (string.IsNullOrEmpty(s))
                {
                    s = "không";
                }
                else if (s.Substring(0, 13) == "không trăm lẻ")
                {
                    s = s.Substring(14);
                }
                else if (s.Substring(0, 11) == "không trăm ")
                {
                    s = s.Substring(11);
                }
                s = s.Substring(0, 1).ToUpper() + s.Substring(1);

                if (negative)
                    s = "Âm " + s;
                return s;
            }
            catch (Exception ex)
            {
                ErrorMessageOkOnly(ex.Message);
                return null;
            }
        }
        //Đổi màu từ UInt sang Color - dùng để bôi màu column header và detail bold
        public static Color UIntToColor(uint color)
        {
            byte a = (byte)(color >> 24);
            byte r = (byte)(color >> 16);
            byte g = (byte)(color >> 8);
            byte b = (byte)(color >> 0);
            return Color.FromArgb(a, r, g, b);
        }
        public static uint ColorToUInt(Color color)
        {
            return (uint)((color.A << 24) | (color.R << 16) |
                          (color.G << 8) | (color.B << 0));
        }
        /// <summary>
        /// Thông báo lỗi, OkOnly, lấy theo MessageID hoặc Message nếu MessageID=0
        /// </summary>
        /// <param name="Message">Chuỗi hiển thị nếu MessageID=0</param>
        public static void ErrorMessageOkOnly(string Message)
        {
            MessageBox.Show(Message, "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Yêu cầu xác nhận
        /// </summary>
        /// <param name="Message">Chuỗi hiển thị</param>
        /// /// <param name="Caption">Chuỗi hiển thị tiêu đề cửa sổ</param>
        /// <param name="DialogType">0: YesNo, 1: YesNoCancel</param>
        public static DialogResult QuestionMessage(string Message, Byte DialogType)
        {
            DialogResult KetQua;
            KetQua = MessageBox.Show(Message, "Xác nhận!", (DialogType == 0) ? MessageBoxButtons.YesNo : MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            return KetQua;
        }
        public static void InfoMessage(string Message)
        {
            UltraDesktopAlert uDA = new UltraDesktopAlert
            {
                UseAppStyling = false,
                UseOsThemes = DefaultableBoolean.False
            };
            UltraDesktopAlertShowWindowInfo uDAInfo = new UltraDesktopAlertShowWindowInfo
            {
                ScreenPosition = ScreenPosition.TopRight,
                Caption = "Thông báo",
                Text = Message
            };
            uDA.Show(uDAInfo);
        }
        public static void filterGrid(UltraGrid ug, String filterText)
        {
            UltraGridBand uBand = null;
            uBand = (ug != null && ug.DisplayLayout.Bands.Count > 0) ? ug.DisplayLayout.Bands[0] : null;
            if (uBand != null && uBand.Columns.Exists("filterColumn"))
            {
                uBand.Columns["filterColumn"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                uBand.ColumnFilters["filterColumn"].FilterConditions.Clear();
                uBand.ColumnFilters["filterColumn"].FilterConditions.Add(FilterComparisionOperator.Contains, filterText);
                if (ug.Rows.GetFilteredInNonGroupByRows().Count() > 0)
                {
                    ug.ActiveRow = ug.Rows.GetFilteredInNonGroupByRows()[0];
                    ug.ActiveRow.Selected = true;
                }
                else
                {
                    ug.ActiveRow = null;
                }
            }
        }
        public static void ExportGrid2Excel(UltraGrid ug)
        {
            String FileName = OpenSaveFileDialog("Chọn file lưu kết quả export", "", "Excel file (*.xls)|*.xls");
            if (FileName != "")
            {
                UltraGridExcelExporter ugE = new UltraGridExcelExporter();
                ugE.Export(ug, FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003);
                ugE.Dispose();
                coreCommon.InfoMessage("Kết xuất thành công!");
                //Open File
                if (coreCommon.QuestionMessage("Đã kết xuất báo cáo, bạn có muốn mở file ra không?", 0) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(FileName);
                }

            }
        }
        public static String OpenSaveFileDialog(String Title, String FileName, String FileExtension)
        {
            SaveFileDialog openFileDlg = new SaveFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = FileExtension,
                Title = Title,
                FileName = FileName,
                RestoreDirectory = true
            };
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                return openFileDlg.FileName;
            }
            else
                return DBNull.Value.ToString();
        }
        public static String OpenFileDialog(String Title, String FileName, String FileExtension)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = FileExtension,
                Title = Title,
                FileName = FileName,
                RestoreDirectory = true
            };
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                return openFileDlg.FileName;
            }
            else
                return DBNull.Value.ToString();
        }
        public static Object NgayHachToan()
        {
            DateTime Ngay;
            try
            {
                SqlConnection connection = new SqlConnection(GlobalVariables.ConnectionString);
                SqlCommand sqlCMD = new SqlCommand("select GetDate()", connection)
                {
                    CommandType = CommandType.Text
                };
                connection.Open();
                Ngay = Convert.ToDateTime(sqlCMD.ExecuteScalar());
                connection.Close();
                return Ngay;
            }
            catch
            {
                return DateTime.Now;
            }
        }
        public static String ChuanHoaChuoi(String Chuoi)
        {
            Chuoi = Chuoi.Trim();
            Chuoi = Chuoi.Replace("\n", "");
            return Chuoi;
        }
        public static String ChuanHoaChuoiUpper(String Chuoi)
        {
            Chuoi = Chuoi.Trim();
            Chuoi = Chuoi.Replace("\n", "");
            Chuoi = Chuoi.ToUpper();
            return Chuoi;
        }
        public static String ChuoiThoiGianDDMMYYYHHMMSS(String ChuoiNgay)
        {
            String Ngay = ChuoiNgay.Substring(0, 2);
            String Thang = ChuoiNgay.Substring(3, 2);
            String Nam = ChuoiNgay.Substring(6, 4);
            String Gio = (ChuoiNgay.Length == 10) ? "00" : ChuoiNgay.Substring(11, 2);
            String Phut = (ChuoiNgay.Length == 10) ? "00" : ChuoiNgay.Substring(14, 2);
            String Giay = (ChuoiNgay.Length == 10) ? "00" : ChuoiNgay.Substring(17, 2);
            return Nam + "-" + Thang + "-" + Ngay + " " + Gio + ":" + Phut + ":" + Giay;
        }
        public static String ChuoiNgayDDMMYYY(String ChuoiNgay)
        {
            String Ngay = ChuoiNgay.Substring(0, 2);
            String Thang = ChuoiNgay.Substring(3, 2);
            String Nam = ChuoiNgay.Substring(6, 4);
            return Nam + "-" + Thang + "-" + Ngay;
        }
        public static string XMLEncode(string str)
        {
            str = str.Replace("&", "&amp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace(@"""", "&quot;");
            str = str.Replace(@"'", "&apos;");
            str = str.Replace("\n", "");
            str = str.Replace("\t", "");
            return str;
        }
        public static Decimal Convert2Decimal(object DecNum)
        {
            if (DecNum == null || DecNum == DBNull.Value)
                return 0;
            else
            {
                Decimal.TryParse(DecNum.ToString(), out decimal dNum);
                return dNum;
            }
        }
        public static Double Convert2Double(object DecNum)
        {
            if (DecNum == null || DecNum == DBNull.Value)
                return 0;
            else
            {
                Double.TryParse(DecNum.ToString(), out double dNum);
                return dNum;
            }
        }
        public static Boolean CheckNumberNullOrZero(object DecNum)
        {
            if (DecNum == null || DecNum == DBNull.Value)
                return true;
            else
            {
                return Convert.ToDecimal(DecNum) == 0;
            }
        }
        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, imageIn.RawFormat);
            return ms.ToArray();
        }
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public static void SetGridColumnWidth(UltraGridColumn column)
        {
            String ColumnKey = column.Key.ToUpper();
            if (column.DataType != typeof(bool))
            {
                if (ColumnKey == "TEN" || ColumnKey.StartsWith("TENDANHMUC") || ColumnKey.StartsWith("DIENGIAI") || ColumnKey.StartsWith("GHICHU") || ColumnKey.StartsWith("NOIDUNG") || ColumnKey.StartsWith("GIATRI"))
                    column.Width = GlobalVariables.DoRongCotDienGiaiGrid;
                else if (ColumnKey == "SO" || ColumnKey == "PO" || ColumnKey == "MA" || ColumnKey == "MAHS" || ColumnKey == "STOCKNUMBER" || ColumnKey == "HTSCODE" || ColumnKey == "KYHIEU" || ColumnKey == "LOAIMANHINH" || ColumnKey == "DEBITNOTE" || ColumnKey == "TENLOAIHANG" || ColumnKey == "BIENSO" || ColumnKey.StartsWith("MADANHMUC") || ColumnKey.StartsWith("DONVITINH") || ColumnKey.StartsWith("NGAY") || ColumnKey.StartsWith("GIO"))
                    column.Width = GlobalVariables.DoRongCotMaGrid;
                else if (ColumnKey.StartsWith("DONGIA") || ColumnKey.StartsWith("SOTIEN") || ColumnKey.StartsWith("TONG"))
                    column.Width = GlobalVariables.DoRongCotMaGrid;
                else
                    column.Width = GlobalVariables.DoRongCotKhacGrid;
            }
            else
            {
                column.Width = 50;
            }
        }
        public static void SetGridColumnMask(UltraGridColumn column)
        {
            String ColumnKey = column.Key.ToUpper();
            if (column.DataType == typeof(DateTime))
            {
                column.MaskInput = GlobalVariables.MaskInputDate;
            }
            if (column.DataType == typeof(double) || column.DataType == typeof(float) || column.DataType == typeof(Decimal) || column.DataType == typeof(Single))
            {
                if (column.Key.StartsWith("SoTien") || column.Key.StartsWith("ThueSuat"))
                {
                    column.CellAppearance.TextHAlign = HAlign.Right;
                    if (column.Key.EndsWith("NguyenTe"))
                    {
                        column.Format = GlobalVariables.FormatReal;
                        column.MaskInput = GlobalVariables.DinhDangNhapReal;
                    }
                    else
                    {
                        column.Format = GlobalVariables.FormatInteger;
                        column.MaskInput = GlobalVariables.DinhDangNhapInteger;

                    }
                }
                else
                {
                    column.CellAppearance.TextHAlign = HAlign.Right;
                    column.Format = GlobalVariables.FormatReal;
                    column.MaskInput = GlobalVariables.DinhDangNhapReal;
                }    
            }
            if (column.DataType == typeof(byte) || column.DataType == typeof(int) || column.DataType == typeof(long) || ColumnKey == "STT" || ColumnKey.StartsWith("SOTHUTU"))
            {
                column.CellAppearance.TextHAlign = HAlign.Right;
                column.Format = GlobalVariables.FormatInteger;
                column.MaskInput = GlobalVariables.DinhDangNhapInteger;
            }
        }
        public static bool IsNull(object obj)
        {
            return (obj == null || obj == DBNull.Value || obj.ToString().Trim() == "" || obj.ToString().ToUpper() == "NULL");
        }
        public static string stringParse(object value)
        {
            return (IsNull(value)) ? "" : value.ToString();
        }
        public static byte? stringParseByte(object value)
        {
            if (IsNull(value))
                return null;
            else
            {
                if (byte.TryParse(value.ToString(), out byte t))
                    return t;
                else
                    return null;
            }
        }
        public static int? stringParseInt(object value)
        {
            if (IsNull(value))
                return null;
            else
            {
                if (int.TryParse(value.ToString(), out int t))
                    return t;
                else
                    return null;
            }
        }
        public static long? stringParseLong(object value)
        {
            if (IsNull(value))
                return null;
            else
            {
                if (long.TryParse(value.ToString(), out long t))
                    return t;
                else
                    return null;
            }
        }
        public static double? stringParseDouble(object value)
        {
            if (IsNull(value))
                return null;
            else
            {
                if (double.TryParse(value.ToString(), out double t))
                    return t;
                else
                    return null;
            }
        }
        public static decimal? stringParseDecimal(object value)
        {
            if (IsNull(value))
                return null;
            else
            {
                if (decimal.TryParse(value.ToString(), out decimal t))
                    return t;
                else
                    return null;
            }
        }
        public static float? stringParseFloat(object value)
        {
            if (IsNull(value))
                return null;
            else
            {
                if (float.TryParse(value.ToString(), out float t))
                    return t;
                else
                    return null;
            }
        }
        public static bool stringParseBoolean(object value)
        {
            if (IsNull(value))
            {
                return false;
            }
            else
            {
                if (bool.TryParse(value.ToString(), out bool t))
                    return t;
                else
                    return false;
            }
        }
        public static DateTime? stringParseDateTime(object value)
        {
            if (IsNull(value))
                return null;
            else
            {
                if (DateTime.TryParse(value.ToString(), out DateTime t))
                    return t;
                else
                    return null;
            }
        }
        public static byte byteParse(object value)
        {
            if (IsNull(value))
                return 0;
            else
            {
                if (byte.TryParse(value.ToString(), out byte t))
                    return t;
                else
                    return 0;
            }
        }
        public static int intParse(object value)
        {
            if (IsNull(value))
                return 0;
            else
            {
                if (int.TryParse(value.ToString(), out int t))
                    return t;
                else
                    return 0;
            }
        }
        public static long longParse(object value)
        {
            if (IsNull(value))
                return 0;
            else
            {
                if (long.TryParse(value.ToString(), out long t))
                    return t;
                else
                    return 0;
            }
        }
        public static double doubleParse(object value)
        {
            if (IsNull(value))
                return 0;
            else
            {
                if (double.TryParse(value.ToString(), out double t))
                    return t;
                else
                    return 0;
            }
        }
        public static decimal decimalParse(object value)
        {
            if (IsNull(value))
                return 0;
            else
            {
                if (decimal.TryParse(value.ToString(), out decimal t))
                    return t;
                else
                    return 0;
            }
        }
        public static float floatParse(object value)
        {
            if (IsNull(value))
                return 0;
            else
            {
                if (float.TryParse(value.ToString(), out float t))
                    return t;
                else
                    return 0;
            }
        }
        public static byte[] ObjectToByteArray(object obj)
        {
            if (obj == null) return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        public static string AllPropertiesAndValues(object obj)
        {
            string strPropertiesAndValues = string.Empty;
            foreach (var prop in obj.GetType().GetProperties())
            {
                if (!prop.Name.StartsWith("ID") && prop.Name != "HinhAnh" && prop.Name != "CreateDate" && prop.Name != "EditDate" && prop.Name != "DataRowState" && !prop.Name.StartsWith("MaDanhMucNguoiSuDung") && !prop.Name.StartsWith("TenDanhMucNguoiSuDung") && !IsNull(prop.GetValue(obj, null)))
                    strPropertiesAndValues += prop.Name + ": " + prop.GetValue(obj, null) + "; ";
            }
            return strPropertiesAndValues;
        }
        public static int MaxTempID(DataTable dt)
        {
            int MaxTempID = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr.RowState != DataRowState.Deleted && int.TryParse(dr["ID"].ToString(), out int tempID))
                    MaxTempID = Math.Min(MaxTempID, tempID);
            }
            return MaxTempID - 1;
        }
        
        public static List<string[]> listLoaiManHinh;
    }
    public static class ThaoTacDuLieu
    {
        public const int Xem = 0;
        public const string DienGiaiXem = "Xem";
        public const int Them = 1;
        public const string DienGiaiThem = "Thêm mới";
        public const int Sua = 2;
        public const string DienGiaiSua = "Chỉnh sửa";
        public const int Copy = 3;
        public const string DienGiaiCopy = "Sao chép";
        public const int Xoa = 4;
        public const string DienGiaiXoa = "Xóa";
    }
    
    
    public static class GlobalVariables
    {
        public static string SolutionName = "";
        //Chuỗi kết nối
        public static String ConnectionString = "";
        public static String ConnectionFileName = Application.StartupPath + @"\DataConnects.xml";
        //Tiền tố
        public const String prefix_DataRelation = "rlt";
        //Tham số định dạng cột dữ liệu
        public static String TenCotNgayThang = "";
        public static String TenCotThoiGian = "";
        public static String TenCotSoLuong = "";
        public static String TenCotKhoiLuong = "";
        public static String TenCotTrongLuong = "";
        public static String TenCotTien = "";
        public static String TenCotGia = "";
        public static String TenCotMaSo = "";
        public static String TenCotDienGiai = "";
        //
        public static string DefaultFixedColumn = "[Stt][MaDanhMucXe][TenDanhMucNguonGocXe][TenDanhMucLoaiXe][TenDanhMucBai]";
        //
        public static Int16 DoRongCotMaGrid = 100;
        public static Int16 DoRongCotDienGiaiGrid = 180;
        public static Int16 DoRongCotKhacGrid = 100;
        //
        public static Double DoRongCotNgayThangReport = 1;
        public static Double DoRongCotSoLuongReport = 1.5;
        public static Double DoRongCotKhoiLuongReport = 1.5;
        public static Double DoRongCotTrongLuongReport = 1.5;
        public static Double DoRongCotTienReport = 1.5;
        public static Double DoRongCotGiaReport = 1;
        public static Double DoRongCotMaSoReport = 1;
        public static Double DoRongCotDienGiaiReport = 4;

        public static String TenCotDropdown = "(IDDanhMucToCongNhan)(TenChuHang)";
        //Từ điển
        public static DataTable dtTuDien;
        //Tham số thông tin đơn vị
        public static object IDDonVi = 8;
        public static String TenDonViCapTren = "";
        public static String TenDonVi = "CÔNG TY TNHH VẬN TẢI DUYÊN HẢI - KHO TASACO";
        public static String DiaChi = "";
        public static String MaSoThue = "";
        public static String TenKtt = "";
        public static String TenGiamDoc = "";
        public static String TenThuQuy = "";
        public static String MauBaoCaoNoiDung = "";
        public static String TenDuLieu = "";
        //Tham số ngôn ngữ
        public static CultureInfo ci = CultureInfo.CreateSpecificCulture("vi-VN");

        public static String FormatThoiGian = "dd/MM/yyyy HH:mm:ss"; //Chuỗi định dạng thời gian
        public static String FormatNgayThangNam = "dd/MM/yyyy"; //Chuỗi định dạng ngày tháng năm
        public static String FormatNgayThang = "dd/mm"; //Chuỗi định dạng ngày tháng

        public static String MaskInputDateTime = "dd/mm/yyyy hh:mm:ss"; //Chuỗi định dạng ngày giờ
        public static String MaskInputDate = "dd/mm/yyyy"; //Chuỗi định dạng ngày tháng
        public static String MaskInputTime = "hh:mm"; //Chuỗi định dạng giờ

        public static String DecimalSymbol = ","; //Dấu phân cách hàng thập phân
        public static String DigitSymbol = "."; //Dấu phân cách hàng nghìn
        
        
        public static String FormatReal = "##,##0.0000";
        public static String DinhDangNhapReal = "-nnn,nnn,nnn,nnn.nnnn";

        public static String FormatInteger = "##,###0";
        public static String DinhDangNhapInteger = "-,nnn,nnn,nnn,nnn";

        public static Int16 LamTronSoLuong = 2;
        public static Int16 LamTronKhoiLuong = 2;
        public static Int16 LamTronCBM = 2;
        public static Int16 LamTronDonGia = 2;
        public static Int16 LamTronDonGiaNgoaiTe = 2;
        public static Int16 LamTronSoTien = 0;
        public static Int16 LamTronSoTienNgoaiTe = 0;

        //Than số người sử dụng đăng nhập
        public static object IDDanhMucNguoiSuDung = "";
        public static String MaDanhMucNguoiSuDung = "";
        public static String TenDanhMucNguoiSuDung = "";
        public static String Password = "";
        public static object IDDanhMucPhanQuyen = "";
        public static Boolean isAdmin = false;
        public static Boolean Logged = false;
        public static Boolean CanLogout = true;
        //Tham số đường dẫn chứa file kết xuất
        public static String OutputDir = Application.StartupPath + @"\Output";
        //Tham số đường dẫn chứa file tạm
        public static String TempDir = Application.StartupPath + @"\Temp\";
        //Tham số đường dẫn chứa file excel mẫu báo cáo
        public static String ExcelTemplateDir = Application.StartupPath + @"\FileMauExcel\";
        //Tham số đường dẫn report
        public static String reportPath = Application.StartupPath + @"\Reports\";
        public static String ChungTuReportPath = Application.StartupPath + @"\Reports\ChungTu\";
        public static String BaoCaoReportPath = Application.StartupPath + @"\Reports\BaoCao\";
        //Tham số file report in chứng từ
        //
        public static String importFileName = "";
        public static String importSheetName = "";
        public static Int32 importFromRow = 2;
        public static Int32 importToRow = 0;
        //Danh sách tham số hệ thống toàn cục
        public const String GlobalSqlParametersList = "(@IDDONVI)(@IDDANHMUCDONVI)(@IDDANHMUCNGUOISUDUNGCREATE)(@IDDANHMUCNGUOISUDUNGEDIT)(@CREATEDATE)(@EDITDATE)(@NAMLAMVIEC)(@IDDANHMUCNGONNGU)";
        //Chuỗi mã hóa
        public const string EncryptPhase = "c@e1n2t3e4c5h6";
        //
        public const string DeleteConfirmMsg = "Dữ liệu đã xóa sẽ không thể khôi phục lại được, bạn có muốn xóa hay không?";
        //
        public const string DanhMucLoaiDoiTuongTaiKhoanKeToan = "TAIKHOANKETOAN";
    }

}
