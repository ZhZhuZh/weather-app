using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FirstApp.Cmd;

public class MoscowWeatherByDate
{
    public MoscowWeatherByDate(string date, string temperature)
    {
        Date = date;
        Temperature = temperature;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Date { get; set; } = string.Empty;

    public string Temperature { get; set; } = string.Empty;
}
