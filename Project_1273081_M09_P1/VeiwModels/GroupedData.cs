using Project_1273081_M09_P1.Models;

namespace Project_1273081_M09_P1.VeiwModels
{
    public class GroupedData
    {
        public string Key { get; set; } = default!;
        public IEnumerable<Subject> Data { get; set; } = default!;
    }
}
