using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSEditor.Models
{
    public enum EDifficulty
    {
        Normal = 0,
        Expert = 1,
        Sandbox = 2,
        Easy = 3
    }

    public enum GaragePosition
    {
        [Display(Name = "Garage Entrance A")] EntranceA = 0,
        [Display(Name = "Garage Entrance B")] EntranceB = 1,
        [Display(Name = "Garage Entrance C")] EntranceC = 2,
        [Display(Name = "Lift A")] LiftA = 3,
        [Display(Name = "Lift B")] LiftB = 4,
        [Display(Name = "Paint Shop")] PaintShop = 5,
        [Display(Name = "Dyno")] Dyno = 6,
        [Display(Name = "Test Path")] TestPath = 7
    }
    public class CMSSave
    {
        public string Name { get; set; }
        public long LastSave { get; set; }
        public int PlayTime { get; set; }
        public int BestRaceTime { get; set; }
        public int TopSpeed { get; set; }
        public int LastUID { get; set; }
        public string BuildVersion { get; set; }
        public bool FinishedTutorial { get; set; }
        public EDifficulty Difficulty { get; set; }
        public Car[] carsInGarage { get; set; }
        public Car[] carsOnParking { get; set; }
        public Jukebox jukeboxData { get; set; }
        public GarageCustomization garageCustomizationData { get; set; }
        public Inventory inventoryData { get; set; }
        public Warehouse warehouseData { get; set; }
        public GroupInventory groupInventoryData { get; set; }
        public CarLifters[] carLiftersData { get; set; }
        public CarLoader carLoaderData { get; set; }
        public UnlockedPosition unlockedPosition { get; set; }
        public UpgradeForPoints upgradeForPointsData { get; set; }
        public UpgradeForMoney upgradeForMoneyData { get; set; }
        public Machines machines { get; set; }
        public Jobs jobsData { get; set; }
        public GlobalDataWrapper globalDataWrapper { get; set; }
        public Player PlayerData { get; set; }
        public ShopListItems[] ShopListItemsData { get; set; }
        public Paintshopdata PaintshopData { get; set; }
    }

    public class Jukebox
    {
        public bool IsPlaying { get; set; }
        public double CurrentSongTime { get; set; }
        public int CurrentRadioStationIndex { get; set; }
        public int CurrentSongIndex { get; set; }
    }

    public class GarageCustomization
    {
        public int[] MaterialIndexes { get; set; }
        public string CurrentTexturePack { get; set; }
    }

    public class Inventory
    {
        public Item[] items { get; set; }
        public Group[] groups { get; set; }
        public int lastUId { get; set; }
    }

    public class Item
    {
        public string ID { get; set; }
        public int UID { get; set; }
        public string NormalID { get; set; }
        public double Condition { get; set; }
        public double Dent { get; set; }
        public bool IsExamined { get; set; }
        public int Quality { get; set; }
        public string Livery { get; set; }
        public double LiveryStrength { get; set; }
        public bool IsPainted { get; set; }
        public TColor Color { get; set; }
        public int RepairAmount { get; set; }
        public bool OutsideRustEnabled { get; set; }
        public Lpdata LPData { get; set; }
        public Wheel WheelData { get; set; }
        public GearBox GearboxData { get; set; }
        public int PaintType { get; set; }
        public Paint PaintData { get; set; }
        public double WashFactor { get; set; }
        public MountObject MountObjectData { get; set; }
    }

    public class TColor
    {
        public double[] Color { get; set; }
    }

    public class Lpdata
    {
        public string Name { get; set; }
        public string Custom { get; set; }
    }

    public class Wheel
    {
        public bool IsBalanced { get; set; }
        public int Size { get; set; }
        public int Width { get; set; }
        public int Profile { get; set; }
        public int ET { get; set; }
    }

    public class GearBox
    {
        public object[] GearRatio { get; set; }
        public double FinalDriveRatio { get; set; }
    }

    public class Paint
    {
        public double metal { get; set; }
        public double roughness { get; set; }
        public double clearCoat { get; set; }
        public double specularity { get; set; }
        public double fresnel { get; set; }
    }

    public class MountObject //TODO: find actual object
    {
        public string ParentPath { get; set; }
        public object[] Condition { get; set; }
        public object[] IsStuck { get; set; }
    }

    public class Group
    {
        public string ID { get; set; }
        public int UID { get; set; }
        public Item[] ItemList { get; set; }
        public double Size { get; set; }
        public bool IsNormalGroup { get; set; }
    }


    public class Warehouse
    {
        public ItemList[] warehouseList { get; set; }
        public int amountOfUnlockedWarehouses { get; set; }
        public GroupList[] warehouseGroupList { get; set; }
        public WarehouseName[] warehouseNamesData { get; set; }
    }

    public class ItemList
    {
        public Item[] myList { get; set; }
    }

    public class GroupList
    {
        public Group[] myList { get; set; }
    }


    public class WarehouseName
    {
        public string Name { get; set; }
        public bool Default { get; set; }
    }

    public class GroupInventory //TODO: Get real object
    {
        public object[] inventoryList { get; set; }
    }

    public class CarLoader
    {
        public GaragePosition[] position { get; set; }
        public int[] specialState { get; set; }
    }

    public class UnlockedPosition
    {
        public bool[] position { get; set; }
    }

    public class UpgradeForPoints
    {
        public string[] id { get; set; }
        public Unlocked[] unlocked { get; set; }
        public int points { get; set; }
    }

    public class Unlocked
    {
        public bool[] element { get; set; }
    }

    public class UpgradeForMoney
    {
        public string[] id { get; set; }
        public Unlocked[] unlocked { get; set; }
        public int points { get; set; }
    }



    public class Machines
    {
        public Group GroupOnWheelBalancer { get; set; }
        public bool WheelWasBalanced { get; set; }
        public Group GroupOnTireChanger { get; set; }
        public bool GroupOnTireChangerIsMounting { get; set; }
        public Group GroupOnSpringClamp { get; set; }
        public bool GroupOnSpringClampIsMounting { get; set; }
        public Group GroupOnEngineStand { get; set; }
        public double EngineStandAngle { get; set; }
        public Item ItemOnBatteryCharger { get; set; }
        public Item ItemOnBrakeLathe { get; set; }
    }

    public class Jobs
    {
        public Job[] jobs { get; set; }
        public Job[] selectedJobs { get; set; }
        public double nextOrderTime { get; set; }
        public double orderTimer { get; set; }
        public int LastUId { get; set; }
        public bool CurrentMissionDone { get; set; }
    }

    public class Job
    {
        public int id { get; set; }
        public int carLoaderID { get; set; }
        public int forXP { get; set; }
        public string carFile { get; set; }
        public int configVersion { get; set; }
        public double[] carColor { get; set; }
        public double timeToEnd { get; set; }
        public bool[] jobType { get; set; }
        public JobTask[] jobTasks { get; set; }
        public int jobPartsCount { get; set; }
        public int Mileage { get; set; }
        public double globalCondition { get; set; }
        public double otherPartsCondition { get; set; }
        public bool BonusToExp { get; set; }
        public bool BonusToMoney { get; set; }
        public string LocalizationID { get; set; }
        public bool IsMission { get; set; }
        public int MissionID { get; set; }
        public bool IconTypeEngine { get; set; }
        public bool IconTypeTiming { get; set; }
        public bool IconTypeSuspension { get; set; }
        public bool IconTypeBrakes { get; set; }
        public bool IconTypeExhaust { get; set; }
        public bool IconTypeGearbox { get; set; }
        public bool IconTypeOil { get; set; }
        public bool IconTypeBody { get; set; }
        public bool IconTypeTuning { get; set; }
    }

    public class JobTask //TODO get real object
    {
        public string type { get; set; }
        public string subtype { get; set; }
        public int IncreaseTuneValue { get; set; }
        public int partsCount { get; set; }
        public object[] partList { get; set; }
        public string desc { get; set; }
        public bool easyMode { get; set; }
        public int moneySpent { get; set; }
        public Item[] Parts { get; set; }
        public bool _done { get; set; }
        public Item[] _partdone { get; set; }
        public Item[] _partfound { get; set; }
        public object[] _name { get; set; }
    }

    public class GlobalDataWrapper
    {
        public int PlayerMoney { get; set; }
        public int PlayerLevel { get; set; }
        public int PlayerExp { get; set; }
        public int PlayerScraps { get; set; }
        public int BarnsAmount { get; set; }
        public int MissionsFinished { get; set; }
        public bool CurrentMissionDone { get; set; }
        public int UnlockedParkingLevels { get; set; }
    }

    public class Player
    {
        public doubleElementList SavedPosition { get; set; }
        public doubleElementList SavedRotation { get; set; }
    }
    public class doubleElementList
    {
        public double[] element { get; set; }
    }


    public class Paintshopdata
    {
        public LastUsedColor[] LastUsedColors { get; set; }
    }

    public class LastUsedColor
    {
        public int r { get; set; }
        public int g { get; set; }
        public int b { get; set; }
        public int a { get; set; }
    }

    public class Car
    {
        [Display(Name = "Car")] public string carToLoad { get; set; }
        public int index { get; set; }
        public double?[] color { get; set; }
        public double?[] factoryColor { get; set; }
        [Display(Name = "Is Customer Car")] public bool customerCar { get; set; }
        [Display(Name = "Order")] public int orderConnection { get; set; }
        public Toools TooolsData { get; set; }
        public Fluids FluidsData { get; set; }
        public string engineSwap { get; set; }
        public Bodypart[] BodyPartsData { get; set; }
        public Part[] PartData { get; set; }
        public int?[] tiresET { get; set; }
        public int?[] wheelsWidth { get; set; }
        public int?[] rimsSize { get; set; }
        public int?[] tiresSize { get; set; }
        public int configVersion { get; set; }
        public LicensePlate LicensePlatesData { get; set; }
        public Engine EngineData { get; set; }
        public double?[] gearRatio { get; set; }
        public double finalDriveRatio { get; set; }
        public CarInfo CarInfoData { get; set; }
        public HeadlampAlignment HeadlampLeftAlignmentData { get; set; }
        public HeadlampAlignment HeadlampRightAlignmentData { get; set; }
        public WheelsAlignment WheelsAlignment { get; set; }
        public bool LightsOn { get; set; }
        public BonusParts BonusPartsData { get; set; }
        public Paint PaintData { get; set; }
        public bool HasCustomPaintType { get; set; }
        public double AdditionalCarRot { get; set; }
    }

    public class Toools
    {
        public bool WelderIsConnected { get; set; }
        public bool InteriorDetailingToolkitIsConnected { get; set; }
        public bool OilbinIsConnected { get; set; }
        public bool EngineCraneIsConnected { get; set; }
        public bool HeadlampAlignmentSystemIsConnected { get; set; }
    }

    public class Fluids
    {
        public Fluid Oil { get; set; }
        public Fluid[] Brake { get; set; }
        public Fluid[] EngineCoolant { get; set; }
        public Fluid[] PowerSteering { get; set; }
        public Fluid[] WindscreenWash { get; set; }
    }

    public class Fluid

    {
        public double Level { get; set; }
        public double Condition { get; set; }
        public FluidID CarFluid { get; set; }
    }

    public class FluidID
    {
        public int m_FileID { get; set; }
        public int m_PathID { get; set; }
    }


    public class LicensePlate
    {
        public string LicensePlateNumberFront { get; set; }
        public string LicensePlateNumberRear { get; set; }
        public string FactoryLicensePlateNumber { get; set; }
        public string LicensePlateFrontTex { get; set; }
        public string LicensePlateRearTex { get; set; }
    }

    public class Engine
    {
        public bool isElectric { get; set; }
        public double idleRpm { get; set; }
        public double idleRpmTorque { get; set; }
        public double idleRpmCurveBias { get; set; }
        public double peakRpm { get; set; }
        public double peakRpmTorque { get; set; }
        public double peakRpmCurveBias { get; set; }
        public double maxRpm { get; set; }
        public double inertia { get; set; }
        public double engineFrictionTorque { get; set; }
        public double engineFrictionRotational { get; set; }
        public double engineFrictionViscous { get; set; }
        public double limiterTriggerRpm { get; set; }
        public double tuningValue { get; set; }
        public bool measured { get; set; }
    }

    public class CarInfo
    {
        public int BuyPrice { get; set; }
        public int Mileage { get; set; }
        public int CarFrom { get; set; }
    }

    public class HeadlampAlignment
    {
        public double Horizontal { get; set; }
        public double Vertical { get; set; }
    }

    public class WheelsAlignment
    {
        public double FL { get; set; }
        public double FR { get; set; }
        public double RL { get; set; }
        public double RR { get; set; }
    }

    public class BonusParts
    {
        public string[] IDs { get; set; }
    }


    public class Bodypart
    {
        public string Id { get; set; }
        public bool Switched { get; set; }
        public double Condition { get; set; }
        public bool Unmounted { get; set; }
        public string TunedID { get; set; }
        public TColor Color { get; set; }
        public int PaintType { get; set; }
        public Paint PaintData { get; set; }
        public string Livery { get; set; }
        public double LiveryStrength { get; set; }
        public bool OutsaidRustEnabled { get; set; }
        public double Dent { get; set; }
        public int Quality { get; set; }
        public double Dust { get; set; }
        public double WashFactor { get; set; }
    }

    public class Part
    {
        private string _Path;
        public string Path
        {
            get => _Path;
            set
            {
                _Path = value;
                var NameParts = _Path.Split('/');
                Category =string.Join("/", NameParts.Reverse().Skip(1).Reverse ());
                Name = Common.TranslatePartName(NameParts.Last());
            }

        }
        public string Category { get; set; }
        public string Name { get; set; }
        public bool Examined { get; set; }
        public double Condition { get; set; }
        public bool Unmounted { get; set; }
        public int Quality { get; set; }
        private string _TuneID;
        public string TunedID {
            get => _TuneID;
            set {
                _TuneID = value;
                TunedIDName= Common.TranslatePartName(TunedID);
            }
        }        
        public string TunedIDName { get; set; }            
        public TColor Color { get; set; }
        public bool IsPainted { get; set; }
        public int PaintType { get; set; }
        public Paint PaintData { get; set; }
        public MountObject MountObjectData { get; set; }
        public double Dust { get; set; }
    }



    public class CarLifters
    {
        public int lifterData { get; set; }
    }

    public class ShopListItems
    {
        public string ID { get; set; }
        public int Amount { get; set; }
        public AdditionalData AdditionalData { get; set; }
    }

    public class AdditionalData
    {
        public string LicensePlateName { get; set; }
        public bool LicensePlate { get; set; }
        public bool Tire { get; set; }
        public bool Rim { get; set; }
        public int Width { get; set; }
        public int Size { get; set; }
        public int Profile { get; set; }
        public int ET { get; set; }
    }

}

