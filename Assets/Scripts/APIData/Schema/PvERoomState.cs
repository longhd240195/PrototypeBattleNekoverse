// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.32
// 

using Colyseus.Schema;

public partial class PvERoomState : Schema {
	[Type(0, "string")]
	public string name = default(string);

	[Type(1, "string")]
	public string id = default(string);

	[Type(2, "map", typeof(MapSchema<EnemyEntity>))]
	public MapSchema<EnemyEntity> enemies = new MapSchema<EnemyEntity>();

	[Type(3, "map", typeof(MapSchema<NekoEntity>))]
	public MapSchema<NekoEntity> nekos = new MapSchema<NekoEntity>();

	[Type(4, "map", typeof(MapSchema<ConsumptionItemEntity>))]
	public MapSchema<ConsumptionItemEntity> consumptionItems = new MapSchema<ConsumptionItemEntity>();

	[Type(5, "int16")]
	public short currentRound = default(short);

	[Type(6, "int16")]
	public short currentTurn = default(short);

	[Type(7, "string")]
	public string phase = default(string);

	[Type(8, "array", typeof(ArraySchema<QueueEntity>))]
	public ArraySchema<QueueEntity> queue = new ArraySchema<QueueEntity>();

	[Type(9, "int16")]
	public short currentIndexEntity = default(short);
}

