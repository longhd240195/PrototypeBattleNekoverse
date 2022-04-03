// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.32
// 

using Colyseus.Schema;

public partial class ConsumptionItemEntity : Schema {
	[Type(0, "string")]
	public string id = default(string);

	[Type(1, "string")]
	public string name = default(string);

	[Type(2, "string")]
	public string consumption_item_type_id = default(string);

	[Type(3, "ref", typeof(ConsumptionItemMetaDataEntity))]
	public ConsumptionItemMetaDataEntity metadata = new ConsumptionItemMetaDataEntity();
}

