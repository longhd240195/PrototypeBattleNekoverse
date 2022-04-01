// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.32
// 

using Colyseus.Schema;

public partial class EnemyEntity : Schema {
	[Type(0, "string")]
	public string id = default(string);

	[Type(1, "string")]
	public string name = default(string);

	[Type(2, "string")]
	public string strategy = default(string);

	[Type(3, "ref", typeof(EnemyMetadataEntity))]
	public EnemyMetadataEntity metadata = new EnemyMetadataEntity();

	[Type(4, "ref", typeof(EnemySkillEntity))]
	public EnemySkillEntity currSkill = new EnemySkillEntity();

	[Type(5, "ref", typeof(ConsumptionItemEntity))]
	public ConsumptionItemEntity currConsumption = new ConsumptionItemEntity();

	[Type(6, "map", typeof(MapSchema<EnemySkillEntity>))]
	public MapSchema<EnemySkillEntity> skills = new MapSchema<EnemySkillEntity>();

	[Type(7, "ref", typeof(EnemyMetadataEntity))]
	public EnemyMetadataEntity currMetadata = new EnemyMetadataEntity();
}

