var random = new Random();

var mix = new Dictionary<string, string> { { "RR", "1" }, { "RP", "2" }, { "RS", "3" }, { "PR", "4" }, { "PP", "5" }, { "PS", "6" }, { "SR", "7" }, { "SP", "8" }, { "SS", "9" } };
var rot = new Dictionary<string, string> { { "R", "P" }, { "P", "S" }, { "S", "R" } };

var length = 0;
var DNA = new string[3];
DNA = DNA.Select(_ => "").ToArray();
var meta = new string[18];
meta = meta.Select(_ => "RPS"[random.Next(3)].ToString()).ToArray();
var skor = new double[18];
var output = "RPS"[random.Next(3)].ToString();

while (true) {
    var hand = Console.ReadLine();
    if (length > 0) {
        for (int i = 0; i < 3; i++) {
            skor[i] = 0.9 * skor[i] + (hand == meta[i] ? 1 : 0) - (hand == rot[rot[meta[i]]] ? 1 : 0);
        }
    }
    length += 1;
    DNA[0] += hand;
    DNA[1] += output;
    DNA[2] += mix[hand + output];
    for (int i = 0; i < 3; i++) {
        var j = Math.Min(11, length);
        var k = -1;
        while (j > 1 && k < 0) {
            j -= 1;
            k = DNA[i].Substring(0, DNA[i].Length - 1).LastIndexOf(DNA[i].Substring(DNA[i].Length - j));
        }
        meta[2 * i] = DNA[0][j + k].ToString();
        meta[2 * i + 1] = rot[DNA[1][j + k].ToString()];
    }
    for (int i = 6; i < 18; i++) {
        meta[i] = rot[meta[i - 6]];
    }
    output = rot[meta[Array.IndexOf(skor, skor.Max())]];
    Console.WriteLine(output);
}