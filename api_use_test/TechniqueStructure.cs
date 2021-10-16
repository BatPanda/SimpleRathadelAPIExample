using System;
using System.Collections.Generic;
using System.Text;

public enum MasteryTypes
{
    SMALL_SUCCESS,
    LARGE_SUCCESS,
    SMALL_PERFECTION,
    GREAT_PERFECTION,
    OBSCURE,
    DIVINE

}

public struct MasteryStruct
{
    /// <summary>
    /// Int order is standard (0 = small success, 5 = divine) when moving from json to enum.
    /// </summary>
    public MasteryTypes type;

    /// <summary>
    /// Total summed points from all stages within this mastery.
    /// </summary>
    public int total_points;

    /// <summary>
    /// Total summed levels from all stages within this mastery.
    /// </summary>
    public int total_levels;

    /// <summary>
    /// Total number of stages in the technique.
    /// </summary>
    public int total_stages;

    /// <summary>
    /// The number of levels per stage.
    /// </summary>
    public int total_levels_per_stage;

    /// <summary>
    /// List of stages in this mastery.
    /// </summary>
    public List<StageStruct> stages;

    /// <summary>
    /// Mastery Struct Constructor
    /// </summary>
    /// <param name="_type">Int order is standard (0 = small success, 5 = divine) when moving from json to enum.</param>
    /// <param name="_total_points">Total summed points from all stages within this mastery.</param>
    /// <param name="_total_levels">Total summed levels from all stages within this mastery.</param>
    /// <param name="_total_stages">Total number of stages in the technique.</param>
    /// <param name="_total_levels_per_stage">The number of levels per stage.</param>
    /// <param name="_stages">List of stages in this mastery.</param>
    public MasteryStruct(MasteryTypes _type, int _total_points, int _total_levels, int _total_stages, int _total_levels_per_stage, List<StageStruct> _stages) {
        type = _type;
        total_points = _total_points;
        total_levels = _total_levels;
        total_stages = _total_stages;
        total_levels_per_stage = _total_levels_per_stage;
        stages = _stages;
    }
}

public struct StageStruct
{
    /// <summary>
    /// Total summed points for this stage.
    /// </summary>
    public int total_points;

    /// <summary>
    /// Total summed levels for this stage.
    /// </summary>
    public int total_levels;

    /// <summary>
    /// List of levels in this stage.
    /// </summary>
    public List<LevelStruct> levels;

    /// <summary>
    /// Stage Struct Constructor
    /// </summary>
    /// <param name="_total_points">Total summed points for this stage.</param>
    /// <param name="_total_levels">Total summed levels for this stage.</param>
    /// <param name="_levels">List of levels in this stage.</param>
    public StageStruct(int _total_points, int _total_levels, List<LevelStruct> _levels) {
        total_points = _total_points;
        total_levels = _total_levels;
        levels = _levels;
    }
}

public struct LevelStruct
{
    /// <summary>
    /// Number of points to complete this specific level.
    /// </summary>
    public int required_points;

    /// <summary>
    /// The type of points needed to make progress in this level. By default it is "standard". Can also be "falconry".
    /// </summary>
    public string point_type;

    /// <summary>
    /// The type of level this is. Can be either: "action", "auxiliary", or "increase".
    /// </summary>
    public string level_type;

    /// <summary>
    /// The string content of the level.
    /// </summary>
    public string level_content;

    /// <summary>
    /// Level Struct Constructor
    /// </summary>
    /// <param name="_required_points">Number of points to complete this specific level.</param>
    /// <param name="_point_type">The type of points needed to make progress in this level. By default it is "standard". Can also be "falconry".</param>
    /// <param name="_level_type">The type of level this is. Can be either: "action", "auxiliary", or "increase".</param>
    /// <param name="_level_content">The string content of the level.</param>
    public LevelStruct(int _required_points, string _point_type, string _level_type, string _level_content) {
        required_points = _required_points;
        point_type = _point_type;
        level_type = _level_type;
        level_content = _level_content;
    }
}

public class TechniqueData
{
    /// <summary>
    /// The uuid of the technique.
    /// </summary>
    public int id;

    /// <summary>
    /// The name of the technique.
    /// </summary>
    public string name;

    /// <summary>
    /// The cluster name this technique belongs in.
    /// </summary>
    public string cluster;

    /// <summary>
    /// The string name of the grade e.g. "red"
    /// </summary>
    public string grade_colour;

    /// <summary>
    /// The level within the grade e.g. 1.
    /// </summary>
    public int grade_number;

    /// <summary>
    /// The total summed points from all masteries.
    /// </summary>
    public int total_points;

    /// <summary>
    /// The total summed levels from all masteries.
    /// </summary>
    public int total_levels;

    /// <summary>
    /// The expected number of stages when complete.
    /// </summary>
    public int full_stage_number;

    /// <summary>
    /// The list of requirements to use the technique.
    /// </summary>
    public List<string> requirements;

    /// <summary>
    /// The list of locations where the technique can be found in game.
    /// </summary>
    public List<string> manual_location;

    /// <summary>
    /// Wether the technique complete or not.
    /// </summary>
    public bool finished;

    /// <summary>
    /// The list of masteries within the technique.
    /// </summary>
    public List<MasteryStruct> masteries; 
}

public class TechniqueStructure
{
    /// <summary>
    /// The number of techniques.
    /// </summary>
    public int technique_quantity;

    /// <summary>
    /// A list of all the techniques.
    /// </summary>
    public List<TechniqueData> techniques;
}