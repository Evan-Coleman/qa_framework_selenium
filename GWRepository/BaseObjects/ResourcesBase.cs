using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace GWRepository.BaseObjects
{
    public static class ResourcesBase
    {
        #region VALUES
        public const int WaitUtilsBaseWaitInMiliSeconds = 200;
        public const int WaitUtilsDefaultValueInMinutes = 4;

        public static string PCDate { get; set; }

        public const string ServerAddress = Enums.ServerAddress.Ecoleman;

        public static string ChromeDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        #endregion

        #region ENUMS
        public static class Enums
        {
            public static class ServerAddress
            {
                public const string Ecoleman = "http://fbmis156.idfbins.com:8180/";
                public const string Dev = "http://fbmsgwpc-dev81/";
            }


            public static class SectionIDeductables
            {
                public const string d500 = "500";
                public const string d1000 = "1000";
                public const string d2500 = "2500";
                public const string d5000 = "5000";
                public const string d10000 = "10000";
                public const string d25000 = "25000";
            }
            public static class CurrentActivitySubject
            {
                public const string SubmittedFullApplication = "Submitted Full Application";
            }
            public static class DownPaymentType
            {
                public const string ACHEFT = "ACH / EFT";
                public const string Cash = "Cash";
                public const string CashEquivalent = "Cash Equivalent";
                public const string Check = "Check";
                public const string CreditDebit = "Credit / Debit";
                public const string IntercompanyTransfer = "Intercompany Transfer";
                public const string TitleCompany = "Title Company";
                public const string Website = "Website";
            }
            public static class PaymentPlanType
            {
                public const string Annual = "Annual Payment Plan";
                public const string Monthly = "Monthly Payment Plan";
                public const string Quarterly = "Quarterly Payment Plan";
                public const string SemiAnnual = "Semi-Annual Payment Plan";
            }
            public static class CenterType
            {
                public const string PC = "pc";
                public const string BC = "bc";
                public const string CM = "ab";
                public const string CC = "cc";
            }
            public static class AddressType
            {
                public const string at1099 = "1099";
                public const string Billing = "Billing";
                public const string Business = "Business";
                public const string Home = "Home";
                public const string Lienholder = "Lienholder";
                public const string Mailing = "Mailing";
                public const string Other = "Other";
                public const string Vendor = "Vendor";
                public const string Work = "Work";
            }
            public static class CreateNew
            {
                public const string CreateNewAlways = "Create New Always";
                public const string DoNotCreateNew ="Don't Create New";
                public const string CreateNewOnlyIfDoesNotExist = "Create New Only If Contact Does Not Already Exist";
            }
            public static class QuoteType
            {
                public const string PolicyIssued = "Policy Issued";
                public const string PolicySubmitted = "Policy Submitted";
                public const string FullApplication = "Full Application";
                public const string QuickQuote = "Quick Quote";
            }
            public static class SquireLines
            {
                public const string SectionsIAndII = "Sections I & II - Property & Liability Line";
                public const string SectionIII = "Section III - Auto Line";
                public const string SectionIV = "Section IV - Inland Marine Line";
            }
            public static class ProductType
            {
                public const string Squire = "Squire";
                public const string Businessowners = "Businessowners";
                public const string StandardInlandMarine = "Standard Inland Marine";
                public const string StandardFireAndLiability = "Standard Fire & Liability";
            }
            public static class CountyIdaho
            {
                public const string Ada = "Ada";
                public const string Adams = "Adams";
                public const string Bannock = "Bannock";
                public const string BearLake = "Bear Lake";
                public const string Benewah = "Benewah";
                public const string Bingham = "Bingham";
                public const string Blaine = "Blaine";
                public const string Boise = "Boise";
                public const string Bonner = "Bonner";
                public const string Bonneville = "Bonneville";
                public const string Boundary = "Boundary";
                public const string Butte = "Butte";
                public const string Camas = "Camas";
                public const string Canyon = "Canyon";
                public const string Caribou = "Caribou";
                public const string Cassia = "Cassia";
                public const string Clark = "Clark";
                public const string Clearwater = "Clearwater";
                public const string Custer = "Custer";
                public const string Elmore = "Elmore";
                public const string Franklin = "Franklin";
                public const string Fremont = "Fremont";
                public const string Gem = "Gem";
                public const string Gooding = "Gooding";
                public const string Idaho = "Idapublic const string ho";
                public const string Jefferson = "Jefferson";
                public const string Jerome = "Jerome";
                public const string Kootenai = "Kootenai";
                public const string Latah = "Latah";
                public const string Lemhi = "Lemhi";
                public const string Lewis = "Lewis";
                public const string Lincoln = "Lincoln";
                public const string Madison = "Madison";
                public const string Minidoka = "Minidoka";
                public const string NezPerce = "Nez Perce";
                public const string Oneida = "Oneida";
                public const string Owyhee = "Owyhee";
                public const string Payette = "Payette";
                public const string Power = "Power";
                public const string Shoshone = "Shoshone";
                public const string Teton = "Teton";
                public const string TwinFalls = "Twin Falls";
                public const string Valley = "Valley";
                public const string Washington = "Washington";
            }
            public static class OrganizationType
            {
                public const string Individual = "Individual";
                public const string Partnership = "Partnership";
                public const string JointVenture = "Joint venture";
                public const string LimitedLiabilityCompany = "Limited Liability Company";
                public const string Corporation = "Corporation";
                public const string TrustOrEstate = "Trust or Estate";
                public const string Organization = "Organization";
                public const string LimitedPartnership = "Limited partnership";
                public const string Other = "Other";
            }
            public static class TermType
            {
                public const string Annual = "Annual";
                public const string Other = "Other";
            }
            public static class PropertyTypePL
            {
                public const string ResidencePremises = "Residence Premises";
                public const string DwellingPremises = "Dwelling Premises";
                public const string VacationHome = "Vacation Home";
                public const string CondominiumDwellingPremises = "Condominium Dwelling Premises";
                public const string CondominiumDwellingPremisesCovE = "Condominium Dwelling Premises Cov E";
                public const string DwellingUnderConstruction = "Dwelling Under Construction";
                public const string CondominiumResidencePremise = "Condominium Residence Premises";
                public const string CondominiumVacationHome = "Condominium Vacation Home";
                public const string Contents = "Contents";
                public const string DwellingPremisesCovE = "Dwelling Premises Cov E";
                public const string ResidencePremisesCovE = "Residence Premises Cov E";
                public const string VacationHomeCovE = "Vacation Home Cov E";
                public const string DwellingUnderConstructionCovE = "Dwelling Under Construction Cov E";
                public const string CondoVacationHomeCovE = "Condo Vacation Home Cov E";
                public const string AlfalfaMill = "Alfalfa Mill";
                public const string Arena = "Arena";
                public const string AwningCanopy = "Awning/Canopy";
                public const string Barn = "Barn";
                public const string BeeStation = "Bee Stations";
                public const string BoatHouse = "Boat House/Dock";
                public const string BoxCar = "Box Car";
                public const string Bridge = "Bridge";
                public const string BunkHouse = "Bunk House";
                public const string Carport = "Carport";
                public const string CommodityShed = "Commodity Shed";
                public const string Corral = "Corral";
                public const string DetachedGarage = "Detached Garage";
                public const string DairyComplex = "Dairy Complex";
                public const string DairyShade = "Dairy Shade";
                public const string DeckPatio = "Deck/Patio";
                public const string Elevator = "Elevator";
                public const string ElevatorLeg = "Elevator Leg";
                public const string ExtractionPlant = "Extraction Plant";
                public const string FarmOffice = "Farm Office";
                public const string FarrowHouse = "Farrow House";
                public const string FeedGrinder = "Feed Grinder";
                public const string FeedStorageShed = "Feed Storage Shed";
                public const string Feeder = "Feeder";
                public const string Fence = "Fence";
                public const string Garage = "Garage";
                public const string GasPump = "Gas Pump";
                public const string GrainSeed = "Grain/Seed";
                public const string Granary = "Granary";
                public const string Greenhouse = "Greenhouse";
                public const string Hangar = "Hangar";
                public const string Harvestore = "Harvestore";
                public const string Hatchery = "Hatchery";
                public const string HayStorage = "Hay Storage";
                public const string HayStrawInOpen = "Hay/Straw In Open";
                public const string HayStrawInStorage = "Hay/Straw In Storage";
                public const string HayStrawWithClearSpace = "Hay/Straw With Clear Space";
                public const string HobbyHouse = "Hobby House";
                public const string HogHouse = "Hog House";
                public const string HoneyExtractionBuilding = "Honey Extraction Building";
                public const string HopsProcessingBuilding = "Hops Processing Building";
                public const string HotTub = "Hot Tub";
                public const string ImplementShed = "Implement Shed";
                public const string Kennel = "Kennel";
                public const string LaborHouse = "Labor House";
                public const string LambingShed = "Lambing Shed";
                public const string ManureBunker = "Manure Bunker";
                public const string MinkBarn = "Mink Barn";
                public const string MintStill = "Mint Still";
                public const string MiscBuilding = "Misc Building";
                public const string Onions = "Onions";
                public const string PeltingShed = "Pelting Shed";
                public const string PoolHouse = "Pool House";
                public const string Potatoes = "Potatoes";
                public const string PoultryHouse = "Poultry House";
                public const string PowerPole = "Power Pole";
                public const string PumpHouse = "Pump House";
                public const string Quonset = "Quonset";
                public const string SatelliteDish = "Satellite Dish";
                public const string ScaleHouse = "Scale House";
                public const string Shed = "Shed";
                public const string Shop = "Shop";
                public const string Sign = "Sign";
                public const string SiloTank = "Silo Tank";
                public const string SolarPanels = "Solar Panels";
                public const string StockShed = "Stock Shed";
                public const string SwimmingPool = "Swimming Pool";
                public const string TackRoom = "Tack Room";
                public const string Trellis = "Trellis";
                public const string TrellisedHops = "Trellised Hops";
                public const string VegetableCellar = "Vegetable Cellar";
                public const string VegetableWarehouse = "Vegetable Warehouse";
                public const string VegetablesInStorage = "Vegetables In Storage";
                public const string WashRoom = "WashRoom";
                public const string Windmill = "Windmill";
            }
            public static class ConstructionType
            {
                public const string Frame = "Frame";
                public const string NonFrame = "Non-Frame";
                public const string ModularManufactured = "Modular/Manufactured";
                public const string MobileHome = "Mobile Home";
            }
            public static class ValuationMethod
            {
                public const string ActualCashValue = "Actual Cash Value";
                public const string ReplacementCostValue = "Replacement Cost Value";
                
            }
            public static class CoverageType
            {
                public const string BroadForm = "Broad Form";
                public const string SpecialForm = "Special Form";
            }
            public static class UserRole
            {
                public const string Agent = "Agent";
                public const string Underwriter = "underwriter";
            }
            public static class GarageType
            {
                public const string NoGarage = "No Garage";
                public const string AttachedGarage = "Attached Garage";
            }
            public static class FoundationType
            {
                public const string None = "No Garage";
                public const string Slab = "Slab";
                public const string RaisedSlab = "Raised Slab";
                public const string PierAndBeam = "Pier and Beam";
                public const string CrawlSpace = "Crawl Space";
                public const string FullBasement = "Full Basement";
                public const string Foundation = "Foundation";
                public const string NoFoundation = "No Foundation";
            }
            public static class RoofType
            {
                public const string CompositionShingles = "Composition Shingles including Asphalt";
                public const string WoodShingles = "Wood Shingles including Shakes";
                public const string RoofingTar = "Roofing Tar and Gravel Metal including Steel";
                public const string FiberCement = "Crawl Space";
                public const string FiberAluminum = "Full Basement";
                public const string Other = "Other";
                public const string Copper = "Copper";
                public const string SlateConcrete = "Slate Concrete";
                public const string ClayTile = "Tile, Clay";
                public const string ConcreteTile = "Tile, Concrete";
            }
            public static class KitchenBathClass
            {
                public const string Basic = "Basic";
                public const string BuilderGrade = "Builder Grade";
                public const string Designer = "Designer";
                public const string Custom = "Custom";
                public const string SemiCustom = "Semi Custom";
            }
            public static class InteriorSprinklerSystemType
            {
                public const string None = "None";
                public const string Full = "Full";
                public const string Partial = "Partial";
            }
        }
        #endregion
    }
}
