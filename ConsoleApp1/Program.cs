using ConsoleApp1.Models;
using Newtonsoft.Json;
public class ReceiptParser
{
    public void ParseJson(string jsonFilePath)
    {
        try
        {
            string jsonText = File.ReadAllText(jsonFilePath);

            List<ReceiptItem> items = JsonConvert.DeserializeObject<List<ReceiptItem>>(jsonText);
            var text = items.FirstOrDefault().description;
            Console.WriteLine(text);
            // If you want to see the coordinate values, you can use this code
            //foreach (ReceiptItem item in items)
            //{
            //    Console.WriteLine(item.description); // Öğe açıklamasını yazdır

            //    Console.WriteLine("Koordinatlar:");
            //    foreach (Vertex vertex in item.boundingPoly.vertices)
            //    {
            //        Console.WriteLine($"x: {vertex.x}, y: {vertex.y}");
            //    }
            //    Console.WriteLine();
            //}
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata: " + ex.Message);
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        ReceiptParser parser = new ReceiptParser();
        parser.ParseJson("veri.json");
    }
}