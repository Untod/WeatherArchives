using NPOI.SS.UserModel;

namespace TestTask_DynamicSun.Controllers
{
    public static class Extensions
    {
        public static string GetCellString(this IRow row, int cellIndex)
        {
            var cell = row.GetCell(cellIndex, MissingCellPolicy.RETURN_NULL_AND_BLANK);
            if (cell == null)
                return string.Empty;

            switch (cell.CellType)
            {
                case CellType.Numeric:
                    return cell.NumericCellValue.ToString();
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Boolean:
                    return cell.BooleanCellValue.ToString();
                default:
                    return string.Empty;
            }
        }
    }
}
