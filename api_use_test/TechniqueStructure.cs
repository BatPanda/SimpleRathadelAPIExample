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
    public MasteryTypes type; //int order is standard (0 = small success, 5 = divine) when moving from json to enum.
    public int total_points; //total summed points from all stages within this mastery.
    public int total_levels; //total summed levels from all stages within this mastery.
    public int total_stages; //total number of stages in the technique.
    public int total_levels_per_stage; //the number of levels per stage.
    public List<StageStruct> stages; //list of stages in this mastery.

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
    public int total_points; //total summed points for this stage.
    public int total_levels; //total summed levels for this stage.
    public List<LevelStruct> levels; //list of levels in this stage

    public StageStruct(int _total_points, int _total_levels, List<LevelStruct> _levels) {
        total_points = _total_points;
        total_levels = _total_levels;
        levels = _levels;
    }
}

public struct LevelStruct
{
    public int required_points; //number of points to complete this specific level.
    public string point_type; //the type of points needed to make progress in this level. By default it is "standard". Can also be "falconry".
    public string level_type; //the type of level this is. Can be either: "action", "auxiliary", or "increase".
    public string level_content; //the string content of the level.

    public LevelStruct(int _required_points, string _point_type, string _level_type, string _level_content) {
        required_points = _required_points;
        point_type = _point_type;
        level_type = _level_type;
        level_content = _level_content;
    }
}

public class TechniqueData
{
    public int id; //the uuid of the technique.
    public string name; //the name of the technique.
    public string cluster; //the cluster name this technique belongs in.
    public string grade_colour; //the string name of the grade e.g. "red"
    public int grade_number; //the level within the grade e.g. 1.
    public int total_points; //the total summed points from all masteries.
    public int total_levels; //the total summed levels from all masteries.
    public int full_stage_number; //the expected number of stages when complete.
    public List<string> requirements; //list of requirements to use the technique.
    public List<string> manual_location; //list of locations where the technique can be found in game.
    public bool finished; //is the technique complete?
    public List<MasteryStruct> masteries; //list of masteries within the technique.
}

class TechniqueStructure
{
    public int technique_quantity; //number of techniques.
    public List<TechniqueData> techniques; //list of all techniques.
}