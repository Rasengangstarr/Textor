using textor.models;
using System;
namespace textor.utils {
    public class SlotUtils {
        public string GetNameForSlotr(BodyPart b) {
            switch (b) {
                case BodyPart.Head:
                    return "HEAD";
                case BodyPart.Hands:
                    return "HANDS";
                case BodyPart.Belt:
                    return "BELT";
                case BodyPart.Implant:
                    return "IMPLANT";
                case BodyPart.LeftArm:
                    return "LEFT ARM";
                case BodyPart.RightArm:
                    return "RIGHT ARM";
                case BodyPart.LeftHand:
                    return "LEFT HAND";
                case BodyPart.RightHand:
                    return "RIGHT HAND";
                case BodyPart.Body:
                    return "BODY";
                default:
                    throw new Exception();
            }
        }
    }
}