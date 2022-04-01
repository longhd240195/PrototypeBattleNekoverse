// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.32
// 

using Colyseus.Schema;

public partial class NekoEntity : Schema {
	[Type(0, "string")]
	public string id = default(string);

	[Type(1, "string")]
	public string name = default(string);

	[Type(2, "ref", typeof(NekoMetadataEntity))]
	public NekoMetadataEntity metadata = new NekoMetadataEntity();

	[Type(3, "ref", typeof(NekoSkillEntity))]
	public NekoSkillEntity currSkill = new NekoSkillEntity();

	[Type(4, "ref", typeof(ConsumptionItemEntity))]
	public ConsumptionItemEntity currConsumption = new ConsumptionItemEntity();

	[Type(5, "ref", typeof(NekoMetadataEntity))]
	public NekoMetadataEntity currMetadata = new NekoMetadataEntity();

	[Type(6, "map", typeof(MapSchema<NekoSkillEntity>))]
	public MapSchema<NekoSkillEntity> skills = new MapSchema<NekoSkillEntity>();
}

