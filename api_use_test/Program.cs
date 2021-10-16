using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args) {
        const string url = "http://multiversewiki.com:8080";
        const string url_parameters = "/techniques";
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
            

        // List data response.
        HttpResponseMessage response = client.GetAsync(url_parameters).Result;
        if (response.IsSuccessStatusCode) {
            var dataObjects = response.Content;
            TechniqueStructure techniques_data = JsonConvert.DeserializeObject<TechniqueStructure>(dataObjects.ReadAsStringAsync().Result);


            //printAllUniqueClusters(techniques_data);
            //printClusterFunc(techniques_data.getNumberOfTechniquesPerCluster());
            //printRandom(techniques_data)
            //printApplyPointFunctionTestResults(techniques_data);
            printIdToName(techniques_data);
            //printLevelPointTest(techniques_data);
            //letsGo(techniques_data);

            startPointIncreaseInterface(techniques_data);
                
        } else {
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }
        // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
        client.Dispose();
    }

    public static void printRandom(TechniqueStructure _tech) {
        int total_global_points = _tech.techniques.Aggregate(0, (_a, _b) => _a + _b.total_points);
        int total_learning_days = (int)Math.Ceiling((float)total_global_points / 2);
        float total_years = total_learning_days / 448;
        Console.WriteLine($"There are currently {_tech.technique_quantity} techniques!");
        Console.WriteLine($"To learn every technique you would need to allocate {total_global_points} points.");
        Console.WriteLine($"Assuming your comprehension bonus is 1 and it cannot increase, and that you always sleep at night, it would take {Math.Ceiling((float)total_global_points / 2)} days to learn everything.");
        Console.WriteLine($"In Rathadel that is {total_years} years!");
    }

    public static void printAllUniqueClusters(TechniqueStructure _tech) {
        List<string> cluster_types = new List<string>();
        _tech.techniques.ForEach((_t) => { if (!cluster_types.Contains(_t.cluster)) { cluster_types.Add(_t.cluster); } });
        cluster_types.ForEach((_c) => Console.WriteLine(_c));
    }

    public static void printClusterFunc(Dictionary<ClusterTypes,int> _cluster_info) {
        Console.WriteLine("Cluster Breakdown:\n=================================");
        foreach (var element in _cluster_info) {
            Console.WriteLine($"{element.Value}: \t {element.Key.clusterTypeEnumToString()}");
        }
    }

    public static void printApplyPointFunctionTestResults(TechniqueStructure _tech) {
        PointGainResultStruct result_one = _tech.applyPoints(new PointGainConfig(30, 0));
        printPointGainResultStruct(result_one);
        PointGainResultStruct result_two = _tech.applyPoints(new PointGainConfig(30, 0, 13));
        printPointGainResultStruct(result_two);
        PointGainResultStruct result_three = _tech.applyPoints(new PointGainConfig(30, 0, 14));
        printPointGainResultStruct(result_three);
        PointGainResultStruct result_four = _tech.applyPoints(new PointGainConfig(30, 0, 15));
        printPointGainResultStruct(result_four);
        PointGainResultStruct result_five = _tech.applyPoints(new PointGainConfig(3000, 0, 0));
        printPointGainResultStruct(result_five);
        PointGainResultStruct result_six = _tech.applyPoints(new PointGainConfig(4000, 0, 0, 0));
        printPointGainResultStruct(result_six);
        PointGainResultStruct result_seven = _tech.applyPoints(new PointGainConfig(3000, 0, 50, 1, new TMaybe<List<MasteryTypes>>(new List<MasteryTypes>() { MasteryTypes.SMALL_SUCCESS, MasteryTypes.LARGE_SUCCESS })));
        printPointGainResultStruct(result_seven);

        PointGainResultStruct result_eight = _tech.applyPoints(new PointGainConfig(1440, 53, 1020));
        printPointGainResultStruct(result_eight);
    }

    public static void printPointGainResultStruct(PointGainResultStruct _pgrs) {
        Console.WriteLine("\n\n");
        Console.WriteLine("Point Gain Results\n=================================");
        Console.WriteLine($"Placed {_pgrs.config_used.points_to_apply} points into technique {_pgrs.config_used.target_technique_id}.");
        Console.WriteLine($"The technique had {_pgrs.config_used.pre_applied_points} points allocated to it already.");
        if (_pgrs.config_used.stage_limit != 0) { Console.WriteLine($"Points placement was restricted to stages 1-{_pgrs.config_used.stage_limit}"); }
        if (_pgrs.config_used.mastery_limit.is_some) { Console.WriteLine($"Points placement was restricted to the following masteries:{_pgrs.config_used.mastery_limit.value.Aggregate("", (_a, _b) => _a += $"\n{_b.ToString()}")}"); }
        if (_pgrs.ran_out_of_levels) { Console.WriteLine($"Warning! Ran out of levels to apply points too!"); }
        Console.WriteLine($"Levels Gained: {_pgrs.levels_gained.Count}.");
        Console.WriteLine($"Points Spent: {_pgrs.points_spent}.");
        Console.WriteLine($"Points Remaining: {_pgrs.remaining_points}.");
        Console.WriteLine($"Gained floating level: {_pgrs.gained_floating_level}.");
        Console.WriteLine("=================================");
        Console.WriteLine(_pgrs.levels_gained.Aggregate("", (_a, _b) => _a += $"\n[{_b.required_points}] {_b.level_content}"));
    }

    public static void printIdToName(TechniqueStructure _tech) {
        Console.WriteLine(_tech.getIdToTechniqueName().Aggregate("", (_a, _b) => _a += $"{_b.Key} => {_b.Value}\n"));
    }

    public static void printLevelPointTest(TechniqueStructure _tech) {
        Console.WriteLine($"Summed levels are worth {_tech.getPointsFromLevelsFromTechnique(new LevelPayloadStruct(40,40,40,40,10,10), 0)} points");
    }

    public static void letsGo(TechniqueStructure _tech) {
        printPointGainResultStruct(_tech.applyPoints(new PointGainConfig(83, 0, _tech.getPointsFromLevelsFromTechnique(new LevelPayloadStruct(10, 10, 10, 10), 0)+10, 1)));
    }

    public static void startPointIncreaseInterface(TechniqueStructure _tech) {
        Console.WriteLine("\n=================================\nPoint Increase Terminal v1.0\n=================================\n\n");
        Console.Write("Please enter the ID of the technique you wish to increase: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine($"\nLoaded {_tech.getIdToTechniqueName()[id]} successfully!\n");
        Console.Write("Please enter the number of points you wish to apply to the technique: ");
        int new_points = int.Parse(Console.ReadLine());
        Console.Write("\nPlease enter the number of levels already obtained for the following:\n");
        Console.Write("Small Success: ");
        int _ss = int.Parse(Console.ReadLine());
        Console.Write("Large Success: ");
        int _ls = int.Parse(Console.ReadLine());
        Console.Write("Small Perfection: ");
        int _sp = int.Parse(Console.ReadLine());
        Console.Write("Great Perfection: ");
        int _gp = int.Parse(Console.ReadLine());
        Console.Write("Obscure: ");
        int _o = int.Parse(Console.ReadLine());
        Console.Write("Divine: ");
        int _d = int.Parse(Console.ReadLine());
        Console.Write("\nPlease enter the number of hanging points left over: ");
        int _h = int.Parse(Console.ReadLine());
        Console.Write("\nPlease enter a stage limiter (0 = none, 1 = stage 1 only, 2 = stage 1 & 2 only, etc...): ");
        int _st = int.Parse(Console.ReadLine());

        printPointGainResultStruct(_tech.applyPoints(new PointGainConfig(new_points, id, _tech.getPointsFromLevelsFromTechnique(new LevelPayloadStruct(_ss, _ls, _sp, _gp, _o, _d), id)+_h, _st)));

        Console.Write("\n\n\nPress enter to apply more points...");
        Console.ReadLine();

        printIdToName(_tech);
        startPointIncreaseInterface(_tech);

    }
}
