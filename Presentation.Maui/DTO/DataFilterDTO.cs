
using Microsoft.AspNetCore.Components;

namespace Presentation.Maui.DTO
{
    public enum DataFilterOption
    {
        Contains,
        BiggerThan,
        SmallerThan,
        Extension
    }
    public class DataFilterDTO
    {
        public string Text { get; private set; }
        public DataFilterOption FilterOption { get; private set; }
        public DataFilterDTO(string text, string filterOption)
        {
            Text = String.IsNullOrEmpty(text)
                ? ""
                : text;
            FilterOption = String.IsNullOrEmpty(filterOption)
                ? 0
                : SetDataFilterOption(filterOption);
        }

        private DataFilterOption SetDataFilterOption(string option)
        {
            switch (option)
            {
                case "Contains": return DataFilterOption.Contains;
                case "BiggerThan": return DataFilterOption.BiggerThan;
                case "SmallerThan": return DataFilterOption.SmallerThan;
                case "Extension": return DataFilterOption.Extension;
                default: return DataFilterOption.Contains;
            }
        }
        public Func<string, bool> GetPerdicate()
        {
            switch (FilterOption)
            {
                case DataFilterOption.Contains:
                    return x => x.Contains(Text);
                case DataFilterOption.BiggerThan:
                    return x => x.Length > Convert.ToInt32(Text);
                case DataFilterOption.SmallerThan:
                    return x => x.Length < Convert.ToInt32(Text);
                case DataFilterOption.Extension:
                    return x => x.EndsWith(Text);
                default:
                    return x => true;
            }
        }
    }
}
