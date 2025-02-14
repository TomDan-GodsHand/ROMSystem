using SqlSugar;

namespace ROMSystem;

[SugarTable("MaintenanceForm")] // 表名，可以根据需要修改
public class MaintenanceForm
{
    /// <summary>
    /// ID
    /// </summary>
    [SugarColumn(IsPrimaryKey = true)] // 设置为主键，并自增
    public string ID { get; set; }

    /// <summary>
    /// 报修地址
    /// </summary>
    public string RepairAddress { get; set; }

    /// <summary>
    /// 维修内容
    /// </summary>
    public string RepairContent { get; set; }

    /// <summary>
    /// 使用材料
    /// </summary>
    public string MaterialsUsed { get; set; }

    /// <summary>
    /// 维修人员
    /// </summary>
    public string RepairPerson { get; set; }

    /// <summary>
    /// 派工时间
    /// </summary>
    public DateTime DispatchTime { get; set; }

    /// <summary>
    /// 电话
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// 报修人
    /// </summary>
    public string Requester { get; set; }
}