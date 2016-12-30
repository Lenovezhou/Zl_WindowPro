using System;
using System.Collections.Generic;
using Game.Msg;
using UnityEngine;
using Game;
using System.ComponentModel;

/// <summary>
/// 服务器和客户端可能需要的一些公用的常量
/// </summary>
public class GlobleClass
{
}

///// <summary>
///// 资源类型
///// </summary>
//enum ResourceType
//{
//    [Description("图片")]
//    PICTURE = 1,
//    [Description("模型")]
//    MODEL,
//    [Description("音频")]
//    AUDIO,
//    [Description("视频")]
//    VIDEO,
//    [Description("场景")]
//    SCENE,
//    [Description("其他")]
//    OTHER,

//}
/// <summary>
/// 客户端和服务器的消息类型
/// </summary>
enum ClickSeverType
{
    SOCKETOFF = 0,
    USER_LOGIN = 1,
    USER_ADD,
    USER_UPDATE,
    HOUSE_ADD = 11,
    HOUSE_DELET,
    HOUSE_UPDATE,
    HOUSE_SELECT,
    HOUSE_SELECTALL,
    HOUSE_UPDATEDATA,
    ROOM_ADD = 21,
    ROOM_DELET,
    ROOM_UPDATE,
    ROOM_SELECT,
    ROOM_SELECTALL,
    PANORAMA_ADD = 31,
    PANORAMA_DELET,
    PANORAMA_UPDATE,
    PANORAMA_SELECT,
    PANORAMA_SELECTALL,
    CURTAIN_ADD = 41,
    CURTAIN_DELET,
    CURTAIN_UPDATE,
    CURTAIN_SELECT,
    CURTAIN_SELECTALL,
    MODULE_ADD = 51,
    MODULE_DELET,
    MODULE_UPDATE,
    MODULE_SELECT,
    MODULE_SELECTALL,
    MODLEPIC_ADD = 61,
    MODLEPIC_DELET,
    MODLEPIC_UPDATE,
    MODLEPIC_SELECT,
    MODLEPIC_SELECTALL,
    REALPIC_ADD = 71,
    REALPIC_DELET,
    REALPIC_UPDATE,
    REALPIC_SELECT,
    REALPIC_SELECTALL,
    SAVE_FILE = 101
}

#region 用户
/// <summary>
/// 用户信息类
/// </summary>
public class User:MsgBase
{
    public int user_id;
    public string user_name = "";
    public string user_username = "";
    public string user_password = "";
    public string user_scour = "";
    public string user_pic = "";

    public User()
    {

    }

    public void Serialize(DynamicPacket packet)
    {
        packet.Write(user_name);
        packet.Write(user_username);
        packet.Write(user_password);
        packet.Write(user_scour);
        packet.Write(user_pic);
    }

    public void Deserialize(DynamicPacket packet)
    {
        packet.Read(out user_name);
        packet.Read(out user_username);
        packet.Read(out user_password);
        packet.Read(out user_scour);
        packet.Read(out user_pic);
    }
}
#endregion

/// <summary>
/// 户型
/// </summary>
public class House : MsgBase
{
    public int house_id;
    public int User_id;
    public string house_name;
    public string house_Pic;
    public string house_Spic;
    public int house_style;
    public void Serialize(DynamicPacket packet)
    {
        packet.Write(User_id);
        packet.Write(house_name);
        packet.Write(house_Pic);
        packet.Write(house_Spic);
        packet.Write(house_style);
    }

    public void Deserialize(DynamicPacket packet)
    {
        packet.Read(out User_id);
        packet.Read(out house_name);
        packet.Read(out house_Pic);
        packet.Read(out house_Spic);
        packet.Read(out house_style);
    }
}
/// <summary>
/// 房间
/// </summary>
public class Room : MsgBase
{
    public int room_id;
    public int house_id;
    public string room_name;
    public Vector3 room_position;
    public Panorama room_ding;
    public Panorama room_qiang;
    public Panorama room_di;
    public void Serialize(DynamicPacket packet)
    {
        packet.Write(house_id);
        packet.Write(room_name);
        packet.Write(room_position.x);
        packet.Write(room_position.y);
        packet.Write(room_position.z);
        packet.Write(room_ding);
        packet.Write(room_qiang);
        packet.Write(room_di);
    }

    public void Deserialize(DynamicPacket packet)
    {
        packet.Read(out house_id);
        packet.Read(out room_name);
        packet.Read(out room_position.x);
        packet.Read(out room_position.y);
        packet.Read(out room_position.z);
        packet.Read(room_ding);
        packet.Read(room_qiang);
        packet.Read(room_di);
    }
}

/// <summary>
/// 房间点（不对应后台表）
/// </summary>
public class RoomPoint : MsgBase
{

    public int room_id;
    public int sequ;
    public Vector3 point_posiition;
    public Vector3 point_eulerangle;
    public Vector3 point_scale;
    public void Serialize(DynamicPacket packet)
    {
        packet.Write(sequ);
        packet.Write(point_posiition.x);
        packet.Write(point_posiition.y);
        packet.Write(point_posiition.z);
        packet.Write(point_eulerangle.x);
        packet.Write(point_eulerangle.y);
        packet.Write(point_eulerangle.z);
        packet.Write(point_scale.x);
        packet.Write(point_scale.y);
        packet.Write(point_scale.z);
    }

    public void Deserialize(DynamicPacket packet)
    {
        packet.Read(out sequ);
        packet.Read(out point_posiition.x);
        packet.Read(out point_posiition.y);
        packet.Read(out point_posiition.z);
        packet.Read(out point_eulerangle.x);
        packet.Read(out point_eulerangle.y);
        packet.Read(out point_eulerangle.z);
        packet.Read(out point_scale.x);
        packet.Read(out point_scale.y);
        packet.Read(out point_scale.z);
    }
}
/// <summary>
/// 全景展示时的全景图片（天、墙、地、家具）
/// </summary>
public class Panorama:MsgBase
{
    public int panorama_id;
    public int room_id;
    public string panorama_name;
    public int panorama_style;
    public int panorama_type;
    public override void Serialize(DynamicPacket packet)
    {
        packet.Write(room_id);
        packet.Write(panorama_name);
        packet.Write(panorama_style);
        packet.Write(panorama_type);
    }

    public override void Deserialize(DynamicPacket packet)
    {
        packet.Read(out room_id);
        packet.Read(out panorama_name);
        packet.Read(out panorama_style);
        packet.Read(out panorama_type);
    }

}
/// <summary>
/// 窗帘整套
/// </summary>
public class Curtain : MsgBase
{
    public int curtain_id;
    public int user_id;
    public string curtain_name;
    public List<Module> curtain_module;
    public string cuerain_spic;
    public void Serialize(DynamicPacket packet)
    {
        packet.Write(user_id);
        packet.Write(curtain_name);
        packet.Write(curtain_module);
        packet.Write(cuerain_spic);
    }

    public void Deserialize(DynamicPacket packet)
    {
        packet.Read(out user_id);
        packet.Read(out curtain_name);
        packet.Read(out curtain_module);
        packet.Read(out cuerain_spic);
    }

}
/// <summary>
/// 窗帘组件
/// </summary>
public class Module:MsgBase
{
    public int module_id;
    public string module_name;
    public int module_type;
    public string module_url;
    public string module_spic;
    public override void Serialize(DynamicPacket packet)
    {
        packet.Write(module_name);
        packet.Write(module_type);
        packet.Write(module_url);
        packet.Write(module_spic);
    }

    public override void Deserialize(DynamicPacket packet)
    {
        packet.Read(out module_name);
        packet.Read(out module_type);
        packet.Read(out module_url);
        packet.Read(out module_spic);
    }

}
/// <summary>
/// 模型贴图
/// </summary>
public class ModlePic : MsgBase
{
    public int modlepic_id;
    public string modlepic_name;
    public int modlepic_style;
    public int modlepic_type;
    public string modlepic_url;
    public string modlepic_spic;
    public void Serialize(DynamicPacket packet)
    {
        packet.Write(modlepic_name);
        packet.Write(modlepic_style);
        packet.Write(modlepic_type);
        packet.Write(modlepic_url);
        packet.Write(modlepic_spic);
    }

    public void Deserialize(DynamicPacket packet)
    {
        packet.Read(out modlepic_name);
        packet.Read(out modlepic_style);
        packet.Read(out modlepic_type);
        packet.Read(out modlepic_url);
        packet.Read(out modlepic_spic);
    }
}

/// <summary>
/// 实景时的图片（地面、墙面、家具（可能是普通图片））
/// </summary>
public class RealPic : MsgBase
{
    public int realpic_id;
    public string realpic_name;
    public int realpic_style;
    public int realpic_type;
    public string realpic_url;
    public string realpic_spic;
    public void Serialize(DynamicPacket packet)
    {
        packet.Write(realpic_name);
        packet.Write(realpic_style);
        packet.Write(realpic_type);
        packet.Write(realpic_url);
        packet.Write(realpic_spic);
    }

    public void Deserialize(DynamicPacket packet)
    {
        packet.Read(out realpic_name);
        packet.Read(out realpic_style);
        packet.Read(out realpic_type);
        packet.Read(out realpic_url);
        packet.Read(out realpic_spic);
    }
}