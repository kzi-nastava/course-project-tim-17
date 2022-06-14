using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HealthcareSystem.Entity.Enumerations;
namespace HealthcareSystem.Entity.RoomModel.MoveEquipmentFiles
{
class MoveEquipmentRequest {
    public ObjectId _id{get;set;}
    [BsonElement("moveDate")]
    public DateTime moveDate{get;set;}
    [BsonElement("moveFrom")]
    public ObjectId moveFrom{get;set;}
    [BsonElement("moveTo")]
    public ObjectId moveTo{get;set;}
    [BsonElement("equipment")]
    public Equipment equipment{get;set;}

    public MoveEquipmentRequest(DateTime moveDate,ObjectId moveFrom,ObjectId moveTo,Equipment equipment) {
        _id = ObjectId.GenerateNewId();
        this.moveDate = moveDate;
        this.moveTo = moveTo;
        this.moveFrom = moveFrom;
        this.equipment = equipment;
    }


}
}