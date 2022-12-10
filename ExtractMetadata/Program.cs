using ExtractData;
using System.Text.Json;
using File = System.IO.File;

Dictionary<string,Metadata> keyValuePairs= new Dictionary<string,Metadata>();
Func<long, DateTime> UnixTimeToDateTime = unixTime => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTime);

using (var client = new HttpClient())
{
    int Number = 0;
    long count = 0;
    for (int i = 0; i <= 10; i++)
    {
      
        var Json = await client.GetStringAsync($"https://api-mainnet.magiceden.dev/v2/collections/y00ts/activities?offset={Number}&limit=1000");
        var objects = JsonSerializer.Deserialize<List<Active>>(Json);
        long? LastMetadata = null;
        foreach (var item in objects)
        {
            bool daley = true;
            if(item.Image != null && item.Price > 0 && item.TokenMint != null)
            {
                Metadata? metadata = new Metadata();
                if (keyValuePairs.ContainsKey(item.TokenMint))
                {
                    metadata = keyValuePairs[item.TokenMint];
                    daley = false;
                }
                else
                {
                    var metadataJson = await client.GetStringAsync($"https://api-mainnet.magiceden.dev/v2/tokens/{item.TokenMint}");
                    metadata = JsonSerializer.Deserialize<Metadata>(metadataJson);
                    keyValuePairs[item.TokenMint] = metadata;
                    daley = true;
                }
                if (metadata.Attributes.Length > 5 && metadata.Attributes[5].Value != "None")
                {
                    CSV(item.Price, metadata.Attributes, UnixTimeToDateTime(item.BlockTime));
                }
                LastMetadata = item.BlockTime;
                Console.Clear();
                Console.WriteLine($"{i}/15");
                Console.WriteLine($"{count}");
                count++;
                if (daley)
                {
                    Console.WriteLine("delay");
                    await Task.Delay(250 * 1);
                }
                else
                {
                    Console.WriteLine("not delay");
                }
                daley = true;
            }
        }
      
        Number += 1000;
    }
}

void CSV(decimal? price, ExtractData.Attribute[] Attributes, DateTime DateTime)
{
    string path = @"c:\temp\y00ts_v5.csv";
    if (!File.Exists(path))
    {
        if (!File.Exists(path))
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine($"Price" +
                    $";{Attributes[0].Trait_type}" +
                    $";{Attributes[1].Trait_type}" +
                    $";{Attributes[2].Trait_type}" +
                    $";{Attributes[3].Trait_type}" +
                    $";{Attributes[4].Trait_type}" +
                    $";{Attributes[5].Trait_type}" +
                    $";DateTime");
            }
        }

    }
    using (StreamWriter sw = File.AppendText(path))
    {
        sw.WriteLine($"{price}" +
        $";{Attributes[0].Value}" +
        $";{Attributes[1].Value}" +
        $";{Attributes[2].Value}" +
        $";{Attributes[3].Value}" +
        $";{Attributes[4].Value}" +
        $";{Attributes[5].Value}" +
        $";{DateTime}");

    }
}
