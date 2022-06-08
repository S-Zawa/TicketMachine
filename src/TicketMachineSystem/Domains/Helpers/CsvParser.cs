using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace TicketMachineSystem.Domains.Helpers
{
    /// <summary>
    /// CSVパーサ
    /// </summary>
    public static class CsvParser
    {
        /// <summary>
        /// CS読み込み
        /// </summary>
        /// <typeparam name="T">型</typeparam>
        /// <param name="filepath">ファイルパス</param>
        /// <param name="encoding">エンコード</param>
        /// <param name="delimiter">デリミタ</param>
        /// <returns>読込結果</returns>
        public static List<T> Read<T>(string filepath, Encoding encoding, string delimiter)
        {
            var config = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                Delimiter = delimiter,
            };
            using (var reader = new StreamReader(filepath, encoding))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<T>().ToList();
            }
        }

        /// <summary>
        /// CSV書き込み
        /// </summary>
        /// <typeparam name="T">型</typeparam>
        /// <param name="obj">書き込み対象</param>
        /// <param name="filepath">ファイルパス</param>
        /// <param name="encoding">エンコード</param>
        /// <param name="delimiter">デリミタ</param>
        public static void Write<T>(IEnumerable<T> obj, string filepath, Encoding encoding, string delimiter)
        {
            var config = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                Delimiter = delimiter,
            };
            using (var reader = new StreamWriter(filepath, false, encoding))
            using (var csv = new CsvWriter(reader, config))
            {
                csv.WriteRecords<T>(obj);
            }
        }
    }
}