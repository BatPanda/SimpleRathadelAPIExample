using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public enum ClusterTypes
{
    MARTIAL_CLUSTERLESS,
    MARTIAL_CONCEALER,
    MARTIAL_DUELLIST,
    MARTIAL_GUNSLINGER,
    MARTIAL_HUNTER,
    MARTIAL_REAVER,
    MARTIAL_ROGUE,
    PROFESSION_ARTIST,
    PROFESSION_CREATION,
    PROFESSION_HUNTING,
    PROFESSION_LANGUAGE,
    PROFESSION_MEDICINAL,
    PROFESSION_MUSICIAN,
    PROFESSION_TALISMAN,
    PROFESSION_THIEF,
    PROFESSION_WORDSMITH,
    INTERNAL_BEAST_INTERNAL_BIRD,
    BEAST_TAMING_FALCONRY,
    INTERNAL_CLUSTERLESS,
    MOVEMENT_CLUSTERLESS,
    INTERNAL_SOUL_CONDENSING,
    MARTIAL_COMBATANT
}

public struct PointGainConfig 
{
    /// <summary>
    /// The amount of points that will be applied to the technique.
    /// </summary>
    public int points_to_apply;

    /// <summary>
    /// The UUID of the technique you are applying points to.
    /// </summary>
    public int target_technique_id;

    /// <summary>
    /// If some, it will only apply points into the masteries in the list.
    /// </summary>
    public TMaybe<List<MasteryTypes>> mastery_limit;

    /// <summary>
    /// The offset from the start of any given stage in points from pre-gained levels.
    /// </summary>
    public List<int> pre_applied_points;

    /// <summary>
    /// The limit for which stages should be applied to. 0 means no stage limit, 1 means you are only putting points into stage 1, 2 means you are putting points into stage 1 and 2, etc.
    /// </summary>
    public int stage_limit;

    /// <summary>
    /// The floating points left over from previous point gains that can be used to unlock more levels now.
    /// </summary>
    public int floating_points;

    /// <summary>
    /// Point gain config constructor
    /// </summary>
    /// <param name="_points_to_apply">The amount of points that will be applied to the technique.</param>
    /// <param name="_target_technique_id">The UUID of the technique you are applying points to.</param>
    public PointGainConfig(int _points_to_apply, int _target_technique_id) {
        points_to_apply = _points_to_apply;
        target_technique_id = _target_technique_id;
        mastery_limit = new TMaybe<List<MasteryTypes>>();
        stage_limit = 0;
        pre_applied_points = Enumerable.Range(0,stage_limit).Select(_ => 0).ToList();
        floating_points = 0;
    }

    /// <summary>
    /// Point gain config constructor
    /// </summary>
    /// <param name="_points_to_apply">The amount of points that will be applied to the technique.</param>
    /// <param name="_target_technique_id">The UUID of the technique you are applying points to.</param>
    /// <param name="_floating_points">The floating points left over from previous point gains that can be used to unlock more levels now.</param>
    public PointGainConfig(int _points_to_apply, int _target_technique_id, int _floating_points) {
        points_to_apply = _points_to_apply;
        target_technique_id = _target_technique_id;
        mastery_limit = new TMaybe<List<MasteryTypes>>();
        stage_limit = 0;
        pre_applied_points = Enumerable.Range(0, stage_limit).Select(_ => 0).ToList();
        floating_points = _floating_points;
    }

    /// <summary>
    /// Point gain config constructor
    /// </summary>
    /// <param name="_points_to_apply">The amount of points that will be applied to the technique.</param>
    /// <param name="_target_technique_id">The UUID of the technique you are applying points to.</param>
    /// <param name="_floating_points">The floating points left over from previous point gains that can be used to unlock more levels now.</param>
    /// <param name="_pre_applied_points">The offset from the start of any given stage in points.</param>
    public PointGainConfig(int _points_to_apply, int _target_technique_id, int _floating_points, List<int> _pre_applied_points) {
        points_to_apply = _points_to_apply;
        target_technique_id = _target_technique_id;
        mastery_limit = new TMaybe<List<MasteryTypes>>();
        pre_applied_points = _pre_applied_points;
        stage_limit = 0;
        floating_points = _floating_points;
    }

    /// <summary>
    /// Point gain config constructor
    /// </summary>
    /// <param name="_points_to_apply">The amount of points that will be applied to the technique.</param>
    /// <param name="_target_technique_id">The UUID of the technique you are applying points to.</param>
    /// <param name="_floating_points">The floating points left over from previous point gains that can be used to unlock more levels now.</param>
    /// <param name="_pre_applied_points">The offset from the start of any given stage in points.</param>
    /// <param name="_stage_limit">The limit for which stages should be applied to. 0 means no stage limit, 1 means you are only putting points into stage 1, 2 means you are putting points into stage 1 and 2, etc.</param>
    public PointGainConfig(int _points_to_apply, int _target_technique_id, int _floating_points, List<int> _pre_applied_points, int _stage_limit) {
        points_to_apply = _points_to_apply;
        target_technique_id = _target_technique_id;
        mastery_limit = new TMaybe<List<MasteryTypes>>();
        pre_applied_points = _pre_applied_points;
        stage_limit = _stage_limit;
        floating_points = _floating_points;
    }

    /// <summary>
    /// Point gain config constructor
    /// </summary>
    /// <param name="_points_to_apply">The amount of points that will be applied to the technique.</param>
    /// <param name="_target_technique_id">The UUID of the technique you are applying points to.</param>
    /// <param name="_floating_points">The floating points left over from previous point gains that can be used to unlock more levels now.</param>
    /// <param name="_pre_applied_points">The offset from the start of any given stage in points.</param>
    /// <param name="_stage_limit">The limit for which stages should be applied to. 0 means no stage limit, 1 means you are only putting points into stage 1, 2 means you are putting points into stage 1 and 2, etc.</param>
    /// <param name="_mastery_limit">If some, it will only apply points into the masteries in the list.</param>
    public PointGainConfig(int _points_to_apply, int _target_technique_id, int _floating_points, List<int> _pre_applied_points, int _stage_limit, TMaybe<List<MasteryTypes>> _mastery_limit) {
        points_to_apply = _points_to_apply;
        target_technique_id = _target_technique_id;
        mastery_limit = _mastery_limit;
        pre_applied_points = _pre_applied_points;
        stage_limit = _stage_limit;
        floating_points = _floating_points;
    }
}
public struct PointGainResultStruct
{
    /// <summary>
    /// The List of level structs gained from the allocated points.
    /// </summary>
    public List<LevelStruct> levels_gained;

    /// <summary>
    /// The floating points left after applying all possible points within given constraints. 
    /// </summary>
    public int remaining_points;

    /// <summary>
    /// The amount of points spent to aquire the levels gained.
    /// </summary>
    public int points_spent;

    /// <summary>
    /// If the allocated points did not reach the amount of points required to unlock the next level, but did due to remaining floating points, this is true.
    /// </summary>
    public bool gained_floating_level;

    /// <summary>
    /// The config used to generate the result.
    /// </summary>
    public PointGainConfig config_used;

    /// <summary>
    /// PointGainResultStruct constructor.
    /// </summary>
    /// <param name="_levels_gained">The List of level structs gained from the allocated points.</param>
    /// <param name="_remaining">The floating points left after applying all possible points within given constraints.</param>
    /// <param name="_spent">The amount of points spent to aquire the levels gained.</param>
    /// <param name="_gained_floating_level">If the allocated points did not reach the amount of points required to unlock the next level, but did due to remaining floating points, this is true.</param>
    /// <param name="_config_used">The config used to generate the result.</param>
    public PointGainResultStruct(List<LevelStruct> _levels_gained, int _remaining, int _spent, bool _gained_floating_level, PointGainConfig _config_used) {
        levels_gained = _levels_gained;
        remaining_points = _remaining;
        points_spent = _spent;
        gained_floating_level = _gained_floating_level;
        config_used = _config_used;
    }
}

public struct LevelPayloadStruct
{
    /// <summary>
    /// A dict containing the amount of levels per mastery a given operation should consider.
    /// </summary>
    public Dictionary<MasteryTypes, int> mastery_levels;

    /// <summary>
    /// The level payload struct is a data type meant to make considering multiple levels over multiple masteries easier to store, especially in function paramaters.
    /// </summary>
    /// <param name="_small_success_levels">The number of levels in small success to consider.</param>
    public LevelPayloadStruct(int _small_success_levels) {
        mastery_levels = new Dictionary<MasteryTypes, int>();
        mastery_levels[MasteryTypes.SMALL_SUCCESS] = _small_success_levels;
    }

    /// <summary>
    /// The level payload struct is a data type meant to make considering multiple levels over multiple masteries easier to store, especially in function paramaters.
    /// </summary>
    /// <param name="_small_success_levels">The number of levels in small success to consider.</param>
    /// <param name="_large_success_levels">The number of levels in large success to consider.</param>
    public LevelPayloadStruct(int _small_success_levels, int _large_success_levels) {
        mastery_levels = new Dictionary<MasteryTypes, int>();
        mastery_levels[MasteryTypes.SMALL_SUCCESS] = _small_success_levels;
        mastery_levels[MasteryTypes.LARGE_SUCCESS] = _large_success_levels;
    }

    /// <summary>
    /// The level payload struct is a data type meant to make considering multiple levels over multiple masteries easier to store, especially in function paramaters.
    /// </summary>
    /// <param name="_small_success_levels">The number of levels in small success to consider.</param>
    /// <param name="_large_success_levels">The number of levels in large success to consider.</param>
    /// <param name="_small_perfection_levels">The number of levels in small perfection to consider.</param>
    public LevelPayloadStruct(int _small_success_levels, int _large_success_levels, int _small_perfection_levels) {
        mastery_levels = new Dictionary<MasteryTypes, int>();
        mastery_levels[MasteryTypes.SMALL_SUCCESS] = _small_success_levels;
        mastery_levels[MasteryTypes.LARGE_SUCCESS] = _large_success_levels;
        mastery_levels[MasteryTypes.SMALL_PERFECTION] = _small_perfection_levels;
    }

    /// <summary>
    /// The level payload struct is a data type meant to make considering multiple levels over multiple masteries easier to store, especially in function paramaters.
    /// </summary>
    /// <param name="_small_success_levels">The number of levels in small success to consider.</param>
    /// <param name="_large_success_levels">The number of levels in large success to consider.</param>
    /// <param name="_small_perfection_levels">The number of levels in small perfection to consider.</param>
    /// <param name="_great_perfection_levels">The number of levels in great perfection to consider.</param>
    public LevelPayloadStruct(int _small_success_levels, int _large_success_levels, int _small_perfection_levels, int _great_perfection_levels) {
        mastery_levels = new Dictionary<MasteryTypes, int>();
        mastery_levels[MasteryTypes.SMALL_SUCCESS] = _small_success_levels;
        mastery_levels[MasteryTypes.LARGE_SUCCESS] = _large_success_levels;
        mastery_levels[MasteryTypes.SMALL_PERFECTION] = _small_perfection_levels;
        mastery_levels[MasteryTypes.GREAT_PERFECTION] = _great_perfection_levels;
    }

    /// <summary>
    /// The level payload struct is a data type meant to make considering multiple levels over multiple masteries easier to store, especially in function paramaters.
    /// </summary>
    /// <param name="_small_success_levels">The number of levels in small success to consider.</param>
    /// <param name="_large_success_levels">The number of levels in large success to consider.</param>
    /// <param name="_small_perfection_levels">The number of levels in small perfection to consider.</param>
    /// <param name="_great_perfection_levels">The number of levels in great perfection to consider.</param>
    /// <param name="_obscure_levels">The number of levels in obscure to consider</param>
    public LevelPayloadStruct(int _small_success_levels, int _large_success_levels, int _small_perfection_levels, int _great_perfection_levels, int _obscure_levels) {
        mastery_levels = new Dictionary<MasteryTypes, int>();
        mastery_levels[MasteryTypes.SMALL_SUCCESS] = _small_success_levels;
        mastery_levels[MasteryTypes.LARGE_SUCCESS] = _large_success_levels;
        mastery_levels[MasteryTypes.SMALL_PERFECTION] = _small_perfection_levels;
        mastery_levels[MasteryTypes.GREAT_PERFECTION] = _great_perfection_levels;
        mastery_levels[MasteryTypes.OBSCURE] = _obscure_levels;
    }

    /// <summary>
    /// The level payload struct is a data type meant to make considering multiple levels over multiple masteries easier to store, especially in function paramaters.
    /// </summary>
    /// <param name="_small_success_levels">The number of levels in small success to consider.</param>
    /// <param name="_large_success_levels">The number of levels in large success to consider.</param>
    /// <param name="_small_perfection_levels">The number of levels in small perfection to consider.</param>
    /// <param name="_great_perfection_levels">The number of levels in great perfection to consider.</param>
    /// <param name="_obscure_levels">The number of levels in obscure to consider.</param>
    /// <param name="_divine_levels">The number of levels in divine to consider.</param>
    public LevelPayloadStruct(int _small_success_levels, int _large_success_levels, int _small_perfection_levels, int _great_perfection_levels, int _obscure_levels, int _divine_levels) {
        mastery_levels = new Dictionary<MasteryTypes, int>();
        mastery_levels[MasteryTypes.SMALL_SUCCESS] = _small_success_levels;
        mastery_levels[MasteryTypes.LARGE_SUCCESS] = _large_success_levels;
        mastery_levels[MasteryTypes.SMALL_PERFECTION] = _small_perfection_levels;
        mastery_levels[MasteryTypes.GREAT_PERFECTION] = _great_perfection_levels;
        mastery_levels[MasteryTypes.OBSCURE] = _obscure_levels;
        mastery_levels[MasteryTypes.DIVINE] = _divine_levels;
    }
}

/// <summary>
/// A version of a maybe for techniques.
/// </summary>
/// <typeparam name="T"></typeparam>
public class TMaybe<T>
{
    public T value { get; private set; }
    public bool is_some { get; private set; }

    public TMaybe(T _val) {
        value = _val;
        is_some = true;
    }
    public TMaybe() {
        is_some = false;
    }

    public TMaybe<A> fmap<A>(Func<T, A> _func) {
        if (is_some) return new TMaybe<A>(_func(value));
        return new TMaybe<A>();
    }

    public TMaybe<A> bind<A>(Func<T, TMaybe<A>> _func) {
        if (is_some) return _func(value);
        return new TMaybe<A>();
    }
}

public static class TechniqueHelper {

    /// <summary>
    /// Checks if a given technique ID exists within a given instance of a TechniqueStructure.
    /// </summary>
    /// <param name="_tech">TechniqueStructure instance.</param>
    /// <param name="_id">Technique ID.</param>
    /// <returns></returns>
    public static bool doesTechniqueIDExist(this TechniqueStructure _tech, int _id) => !(_id < 0 || _id >= _tech.technique_quantity);

    /// <summary>
    /// Returns a dictionary with a key value of every ID to a string value of that ID's name within a given TechniqueStructure instance.
    /// </summary>
    /// <param name="_tech">TechniqueStructure instance.</param>
    /// <returns></returns>
    public static Dictionary<int, string> getIdToTechniqueName(this TechniqueStructure _tech) => _tech.techniques.Aggregate(new Dictionary<int, string>(), (_a, _b) => { _a[_b.id] = _b.name; return _a; });

    /// <summary>
    /// Converts the cluster type enum to the string version of the cluster name.
    /// </summary>
    /// <param name="_cluster_type">Cluster Types enum.</param>
    /// <returns></returns>
    public static string clusterTypeEnumToString(this ClusterTypes _cluster_type) => _cluster_type switch
    {
        ClusterTypes.MARTIAL_CLUSTERLESS => "Martial - Clusterless",
        ClusterTypes.MARTIAL_CONCEALER => "Martial - Concealer",
        ClusterTypes.MARTIAL_DUELLIST => "Martial - Duellist",
        ClusterTypes.MARTIAL_GUNSLINGER => "Martial - Gunslinger",
        ClusterTypes.MARTIAL_HUNTER => "Martial - Hunter",
        ClusterTypes.MARTIAL_REAVER => "Martial - Reaver",
        ClusterTypes.MARTIAL_ROGUE => "Martial - Rogue",
        ClusterTypes.PROFESSION_ARTIST => "Profession - Artist",
        ClusterTypes.PROFESSION_CREATION => "Profession - Creation",
        ClusterTypes.PROFESSION_HUNTING => "Profession - Hunting",
        ClusterTypes.PROFESSION_LANGUAGE => "Profession - Language",
        ClusterTypes.PROFESSION_MEDICINAL => "Profession - Medicinal",
        ClusterTypes.PROFESSION_MUSICIAN => "Profession - Musician",
        ClusterTypes.PROFESSION_TALISMAN => "Profession - Talisman",
        ClusterTypes.PROFESSION_THIEF => "Profession - Thief",
        ClusterTypes.PROFESSION_WORDSMITH => "Profession - Wordsmith",
        ClusterTypes.INTERNAL_BEAST_INTERNAL_BIRD => "Internal Beast -Internal Bird",
        ClusterTypes.BEAST_TAMING_FALCONRY => "Beast Taming - Falconry",
        ClusterTypes.INTERNAL_CLUSTERLESS => "Internal - Clusterless",
        ClusterTypes.MOVEMENT_CLUSTERLESS => "Movement - Clusterless",
        ClusterTypes.INTERNAL_SOUL_CONDENSING => "Internal - Soul Condensing",
        ClusterTypes.MARTIAL_COMBATANT => "Martial - Combatant",
        _ => throw new ArgumentException($"'{_cluster_type}' does not have a registered literal string. Please add one to clusterTypeEnumToString() function.")
    };

    /// <summary>
    /// Converts a string into a Cluster Types enum value if possible.
    /// </summary>
    /// <param name="_cluster_string">The string to try convert.</param>
    /// <returns></returns>
    public static ClusterTypes stringToClusterTypeEnum(this string _cluster_string) => _cluster_string.ToLower() switch
    {
        "martial - clusterless" => ClusterTypes.MARTIAL_CLUSTERLESS,
        "martial - concealer" => ClusterTypes.MARTIAL_CONCEALER,
        "martial - duellist" => ClusterTypes.MARTIAL_DUELLIST,
        "martial - gunslinger" => ClusterTypes.MARTIAL_GUNSLINGER,
        "martial - hunter" => ClusterTypes.MARTIAL_HUNTER,
        "martial - reaver" => ClusterTypes.MARTIAL_REAVER,
        "martial - rogue" => ClusterTypes.MARTIAL_ROGUE,
        "profession - artist" => ClusterTypes.PROFESSION_ARTIST,
        "profession - creation" => ClusterTypes.PROFESSION_CREATION,
        "profession - hunting" => ClusterTypes.PROFESSION_HUNTING,
        "profession - language" => ClusterTypes.PROFESSION_LANGUAGE,
        "profession - medicinal" => ClusterTypes.PROFESSION_MEDICINAL,
        "profession - musician" => ClusterTypes.PROFESSION_MUSICIAN,
        "profession - talisman" => ClusterTypes.PROFESSION_TALISMAN,
        "profession - thief" => ClusterTypes.PROFESSION_THIEF,
        "profession - wordsmith" => ClusterTypes.PROFESSION_WORDSMITH,
        "internal beast - internal bird" => ClusterTypes.INTERNAL_BEAST_INTERNAL_BIRD,
        "beast taming - falconry" => ClusterTypes.BEAST_TAMING_FALCONRY,
        "internal - clusterless" => ClusterTypes.INTERNAL_CLUSTERLESS,
        "movement - clusterless" => ClusterTypes.MOVEMENT_CLUSTERLESS,
        "internal - soul condensing" => ClusterTypes.INTERNAL_SOUL_CONDENSING,
        "martial - combatant" => ClusterTypes.MARTIAL_COMBATANT,
        _ => throw new ArgumentException($"'{_cluster_string}' does not have a registered enum associated with it. Please add one to stringToClusterTypeEnum() function.")
    };

    /// <summary>
    /// Returns a dictionary with a key value of a cluster type with a key value of an int representing the number of techniques that exist within that cluster in a given TechniqueStructure instance.
    /// </summary>
    /// <param name="_tech">TechniqueStructure instance.</param>
    /// <returns></returns>
    public static Dictionary<ClusterTypes, int> getNumberOfTechniquesPerCluster(this TechniqueStructure _tech) { Dictionary<ClusterTypes, int> ret = new Dictionary<ClusterTypes, int>(); _tech.techniques.ForEach((_t) => { if (ret.ContainsKey(_t.cluster.stringToClusterTypeEnum())) { ret[_t.cluster.stringToClusterTypeEnum()] += 1; } else { ret[_t.cluster.stringToClusterTypeEnum()] = 1; } }); return ret;}

    /// <summary>
    /// Considers a point gain config and generates a point gain result based on it. Can be used to see what results you would have after allocating a certain amount of points to a technique.
    /// </summary>
    /// <param name="_tech">TechniqueStructure instance.</param>
    /// <param name="_config">A Point Gain Config used to determain how the points are applied to a given technique.</param>
    /// <returns></returns>
    public static PointGainResultStruct applyPoints(this TechniqueStructure _tech, PointGainConfig _config) {
        if (!_tech.doesTechniqueIDExist(_config.target_technique_id)) { throw new ArgumentException($"A technique with id '{_config.target_technique_id}' does not exist."); }
        return _tech.techniques[_config.target_technique_id].applyPoints(_config);
    }

    /// <summary>
    /// Considers a point gain config and generates a point gain result based on it. Can be used to see what results you would have after allocating a certain amount of points to this technique.
    /// Because of this, the target id in the point gain config is ignored.
    /// </summary>
    /// <param name="_tech_data">Technique Data instance.</param>
    /// <param name="_config">A Point Gain Config used to determain how the points are applied to a given technique.</param>
    /// <returns></returns>
    public static PointGainResultStruct applyPoints(this TechniqueData _tech_data, PointGainConfig _config) {
        List<LevelStruct> gained_levels = new List<LevelStruct>();
        int points_spent = 0;
        int floating_points = _config.floating_points;
        List<int> offset_points = _config.pre_applied_points;
        int points_left = _config.points_to_apply;
        bool gained_floating_level = false;

        List<MasteryStruct> valid_m = _config.mastery_limit.is_some ? _tech_data.masteries.Where(_m => _config.mastery_limit.value.Contains(_m.type)).ToList() : _tech_data.masteries;

        Dictionary<MasteryTypes,List<StageStruct>> valid_s = _config.stage_limit != 0 ? valid_m.Select(_m => (_m.type,_m.stages.Take(_config.stage_limit).ToList())).ToDictionary(x=>x.type,x=>x.Item2) : valid_m.Select(_m => (_m.type,_m.stages)).ToDictionary(x=>x.type,x=>x.stages);

        Dictionary<MasteryTypes,(List<StageStruct>,int)> paired_valid_s = valid_s.Select(_p => (_p.Key, (_p.Value, offset_points.ElementAt((int)_p.Key)))).ToDictionary(_x => _x.Key, _y => _y.Item2);

        (int, List<LevelStruct>) getUnlockedLevels(List<LevelStruct> _xs, int _offs) =>
            _xs.Aggregate((_offs, new List<LevelStruct>()), ((int, List<LevelStruct>) _acc, LevelStruct _x) => { if (_x.required_points <= _acc.Item1) { _acc.Item2.Add(_x); return (_acc.Item1 - _x.required_points, _acc.Item2); } else return (-1, _acc.Item2); });

        List<LevelStruct> pre_unlocked_levels = paired_valid_s.Values.SelectMany(_p => getUnlockedLevels(_p.Item1.SelectMany(_s => _s.levels).ToList(), _p.Item2).Item2).ToList(); 
        
        List<LevelStruct> valid_l = _config.pre_applied_points.Sum() != 0 ? valid_s.SelectMany(_s1 => _s1.Value.SelectMany(_s2 => _s2.levels)).Where(_l => !pre_unlocked_levels.Contains(_l)).ToList() : valid_s.SelectMany(_s1 => _s1.Value.SelectMany(_s2 => _s2.levels)).ToList();
        
        gained_levels = valid_l.Where(_l => { if (points_left >= _l.required_points) { points_left -= _l.required_points; points_spent += _l.required_points; return true; } else if (points_left+floating_points >= _l.required_points) {floating_points -= _l.required_points; if (floating_points < 0) { points_left += floating_points; floating_points = 0; } points_spent += _l.required_points; gained_floating_level = true; return true; } else return false; }).ToList();
        
        points_left += floating_points;

        return new PointGainResultStruct(gained_levels, points_left, points_spent, gained_floating_level, _config);
    }

    /// <summary>
    /// Examins a level payload struct to determain how many points that configuration of levels would cost as points with a given technique.
    /// </summary>
    /// <param name="_tech">Technique Data instance.</param>
    /// <param name="_levels">A Level Payload Struct.</param>
    /// <param name="_id">ID the targeted technique.</param>
    /// <returns></returns>
    public static List<int> getPointsFromLevelsFromTechnique(this TechniqueStructure _tech, LevelPayloadStruct _levels, int _id) {
        if (!_tech.doesTechniqueIDExist(_id)) { throw new ArgumentException($"A technique with id '{_id}' does not exist."); }
        return _tech.techniques[_id].getPointsFromLevelsFromTechnique(_levels);
    }

    /// <summary>
    /// Examins a level payload struct to determain how many points that configuration of levels would cost as points with a given technique.
    /// </summary>
    /// <param name="_tech_data">Technique Data instance.</param>
    /// <param name="_levels">A Level Payload Struct.</param>
    /// <returns></returns>
    public static List<int> getPointsFromLevelsFromTechnique(this TechniqueData _tech_data, LevelPayloadStruct _levels) {
        List<int> output = new List<int>();
        _tech_data.masteries.ForEach(_m => output.Add(_m.stages.SelectMany(_s => _s.levels).Take(_levels.mastery_levels[_m.type]).Select(_l => _l.required_points).Sum()));
        return output;
    }

}

