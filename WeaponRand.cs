using CalamityMod;
using CalamityMod.Projectiles.Summon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using static Terraria.ID.ItemID;

namespace WeaponRand;

public sealed partial class WeaponRand : Mod
{
    public static WeaponRand Instance { get; private set; }
    public static List<short> PHWeapons =
    [
        CopperShortsword,
        TinShortsword,
        IronShortsword,
        LeadShortsword,
        SilverShortsword,
        TungstenShortsword,
        GoldShortsword,
        PlatinumShortsword,
        WoodenSword,
        BorealWoodSword,
        RichMahoganySword,
        PalmWoodSword,
        EbonwoodSword,
        ShadewoodSword,
        AshWoodSword,
        CactusSword,
        ZombieArm,
        CopperBroadsword,
        TinBroadsword,
        IronBroadsword,
        LeadBroadsword,
        SilverBroadsword,
        TungstenBroadsword,
        GoldBroadsword,
        PlatinumBroadsword,
        BoneSword,
        EnchantedSword,
        IceBlade,
        BatBat,
        Katana,
        CandyCaneSword,
        LightsBane,
        TentacleSpike,
        BloodButcherer,
        PurpleClubberfish,
        BluePhaseblade,
        RedPhaseblade,
        GreenPhaseblade,
        OrangePhaseblade,
        PurplePhaseblade,
        WhitePhaseblade,
        YellowPhaseblade,
        Starfury,
        BeeKeeper,
        BladeofGrass,
        Muramasa,
        FieryGreatsword,
        NightsEdge,
        FalconBlade,
        Terragrim,
        AntlionClaw,
        Gladius,
        Ruler,
        Flymeal,
        BladedGlove,
        DyeTradersScimitar,
        StylistKilLaKillScissorsIWish,
        Keybrand,
        Spear,
        Trident,
        TheRottedFork,
        Swordfish,
        DarkLance,
        WoodenBoomerang,
        EnchantedBoomerang,
        IceBoomerang,
        Shroomerang,
        Trimarang,
        BloodyMachete,
        FruitcakeChakram,
        ThornChakram,
        Flamarang,
        CombatWrench,
        ChainKnife,
        Mace,
        FlamingMace,
        BallOHurt,
        TheMeatball,
        BlueMoon,
        Sunfury,
        WoodYoyo,
        Rally,
        CorruptYoyo,
        CrimsonYoyo,
        JungleYoyo,
        Code1,
        HiveFive,
        Valor,
        Cascade,
        WoodenBow,
        BorealWoodBow,
        RichMahoganyBow,
        PalmWoodBow,
        EbonwoodBow,
        ShadewoodBow,
        AshWoodBow,
        CopperBow,
        TinBow,
        IronBow,
        LeadBow,
        SilverBow,
        TungstenBow,
        GoldBow,
        PlatinumBow,
        DemonBow,
        TendonBow,
        MoltenFury,
        BeesKnees,
        HellwingBow,
        BloodRainBow,
        FlareGun,
        Minishark,
        Blowpipe,
        FlintlockPistol,
        SnowballCannon,
        Boomstick,
        Revolver,
        Sandgun,
        Musket,
        TheUndertaker,
        StarCannon,
        Blowgun,
        QuadBarrelShotgun,
        Handgun,
        PewMaticHorn,
        PhoenixBlaster,
        RedRyder,
        Shuriken,
        ThrowingKnife,
        PoisonedKnife,
        Snowball,
        Grenade,
        StickyGrenade,
        BouncyGrenade,
        SpikyBall,
        Bone,
        BoneDagger,
        RottenEgg,
        StarAnise,
        MolotovCocktail,
        FrostDaggerfish,
        Javelin,
        BoneJavelin,
        Beenade,
        Harpoon,
        AleThrowingGlove,
        PainterPaintballGun,
        WandofSparking,
        WandofFrosting,
        AmethystStaff,
        TopazStaff,
        SapphireStaff,
        EmeraldStaff,
        RubyStaff,
        DiamondStaff,
        AmberStaff,
        Vilethorn,
        CrimsonRod,
        WeatherPain,
        MagicMissile,
        AquaScepter,
        Flamelash,
        BeeGun,
        SpaceGun,
        WaterBolt,
        DemonScythe,
        BookofSkulls,
        FlowerofFire,
        ThunderSpear,
        ThunderStaff,
        ZapinatorGray,
        SlimeStaff,
        HornetStaff,
        ImpStaff,
        DD2FlameburstTowerT1Popper,
        DD2BallistraTowerT1Popper,
        DD2ExplosiveTrapT1Popper,
        DD2LightningAuraT1Popper,
        VampireFrogStaff,
        BabyBirdStaff,
        FlinxStaff,
        AbigailsFlower,
        HoundiusShootius,
        BlandWhip,
        ThornWhip,
        BoneWhip,
        // Not in wiki
        Umbrella,
        PaperAirplaneA,
        PaperAirplaneB,
        TragicUmbrella,
    ];
    public static List<short> HMWeapons = 
    [
        PearlwoodSword,
        TaxCollectorsStickOfDoom,
        SlapHand,
        BreakerBlade,
        CobaltSword,
        PalladiumSword,
        BluePhasesaber,
        GreenPhasesaber,
        OrangePhasesaber,
        PurplePhasesaber,
        RedPhasesaber,
        WhitePhasesaber,
        YellowPhasesaber,
        DD2SquireDemonSword,
        MythrilSword,
        OrichalcumSword,
        ChlorophyteSaber,
        Cutlass,
        Frostbrand,
        AdamantiteSword,
        Seedler,
        BeamSword,
        TitaniumSword,
        Bladetongue,
        Excalibur,
        TrueExcalibur,
        FetidBaghnakhs,
        Keybrand,
        PsychoKnife,
        ChlorophyteClaymore,
        TheHorsemansBlade,
        ChristmasTreeSword,
        TrueNightsEdge,
        TerraBlade,
        DD2SquireBetsySword,
        InfluxWaver,
        CobaltNaginata,
        PalladiumPike,
        MythrilHalberd,
        OrichalcumHalberd,
        AdamantiteGlaive,
        TitaniumTrident,
        Gungnir,
        MonkStaffT2,
        ChlorophytePartisan,
        MushroomSpear,
        ObsidianSwordfish,
        NorthPole,
        Anchor,
        KOCannon,
        ChainGuillotines,
        DaoofPow,
        FlowerPow,
        Flairon,
        GolemFist,
        DripplerFlail,
        FormatC,
        Gradient,
        Chik,
        HelFire,
        Amarok,
        Code2,
        Yelets,
        RedsYoyo,
        ValkyrieYoyo,
        Kraken,
        TheEyeOfCthulhu,
        FlyingKnife,
        LightDisc,
        Bananarang,
        PossessedHatchet,
        PaladinsHammer,
        BouncingShield,
        VampireKnives,
        ShadowFlameKnife,
        ScourgeoftheCorruptor,
        DayBreak,
        Arkhalis,
        MonkStaffT1,
        MonkStaffT3,
        SolarEruption,
        DeathSickle,
        IceSickle,
        PearlwoodBow,
        Marrow,
        IceBow,
        DaedalusStormbow,
        ShadowFlameBow,
        DD2PhoenixBow,
        PulseBow,
        DD2BetsyBow,
        Tsunami,
        Phantasm,
        FairyQueenRangedItem,
        ClockworkAssaultRifle,
        Gatligator,
        Shotgun,
        OnyxBlaster,
        CoinGun,
        Uzi,
        Megashark,
        VenusMagnum,
        TacticalShotgun,
        SniperRifle,
        CandyCornRifle,
        ChainGun,
        Xenopopper,
        VortexBeater,
        CobaltRepeater,
        PalladiumRepeater,
        MythrilRepeater,
        OrichalcumRepeater,
        AdamantiteRepeater,
        TitaniumRepeater,
        HallowedRepeater,
        ChlorophyteShotbow,
        StakeLauncher,
        GrenadeLauncher,
        ProximityMineLauncher,
        RocketLauncher,
        NailGun,
        Stynger,
        JackOLanternLauncher,
        SnowmanCannon,
        ElectrosphereLauncher,
        FireworksLauncher,
        Toxikarp,
        DartPistol,
        DartRifle,
        Flamethrower,
        PiranhaGun,
        ElfMelter,
        IceRod,
        FlowerofFrost,
        CrystalVileShard,
        SoulDrain,
        ClingerStaff,
        BookStaff,
        FrostStaff,
        MeteorStaff,
        RainbowRod,
        NimbusRod,
        PoisonStaff,
        NettleBurst,
        VenomStaff,
        ApprenticeStaffT3,
        StaffofEarth,
        ShadowbeamStaff,
        BatScepter,
        BlizzardStaff,
        InfernoFork,
        SpectreStaff,
        LaserRifle,
        LeafBlower,
        HeatRay,
        BubbleGun,
        RainbowGun,
        WaspGun,
        LaserMachinegun,
        ChargedBlasterCannon,
        ZapinatorOrange,
        CursedFlames,
        GoldenShower,
        CrystalStorm,
        MagnetSphere,
        RazorbladeTyphoon,
        MagicDagger,
        MagicalHarp,
        MedusaHead,
        UnholyTrident,
        ShadowFlameHexDoll,
        SkyFracture,
        SpiritFlame,
        CrystalSerpent,
        ToxicFlask,
        Razorpine,
        NebulaArcanum,
        NebulaBlaze,
        FireWhip,
        CoolWhip,
        SwordWhip,
        ScytheWhip,
        MaceWhip,
        RainbowWhip,
        SanguineStaff,
        StormTigerStaff,
        OpticStaff,
        PirateStaff,
        DeadlySphereStaff,
        PygmyStaff,
        RavenStaff,
        SpiderStaff,
        TempestStaff,
        XenoStaff,
        StardustCellStaff,
        StardustDragonStaff,
        EmpressBlade,
        QueenSpiderStaff,
        DD2LightningAuraT2Popper,
        DD2FlameburstTowerT2Popper,
        DD2ExplosiveTrapT2Popper,
        DD2BallistraTowerT2Popper,
        StaffoftheFrostHydra,
        DD2LightningAuraT3Popper,
        DD2FlameburstTowerT3Popper,
        DD2ExplosiveTrapT3Popper,
        DD2BallistraTowerT3Popper,
        // Not in wiki
        PartyGirlGrenade,
        SuperStarCannon,
        SharpTears,
        SparkleGuitar,
        Smolstar,
        JoustingLance,
        ShadowJoustingLance,
        HallowJoustingLance,
        PiercingStarlight,
        FairyQueenMagicItem,
        PrincessWeapon,
        HamBat,
        WaffleIron
    ];
    public static List<short> PostMLWeapons =
    [
        StarWrath,
        Meowmere,
        Terrarian,
        SDMG,
        Celeb2,
        LunarFlareBook,
        LastPrism,
        MoonlordTurretStaff,
        RainbowCrystalStaff
    ];
    public static List<short> PostDoGWeapons = 
    [
        Zenith,
    ];
    public WeaponRand()
    {
        Instance = this;
    }
    public override void PostSetupContent()
    {
        if (ModLoader.HasMod("CalamityMod"))
            CalamitySupport();
        if (ModLoader.HasMod("ThoriumMod"))
            ThoriumSupport();

        /*
        for (short i = Count; i < ItemLoader.ItemCount; i++)
        {
            var item = ContentSamples.ItemsByType[i];
            if (item is not { damage: > 0, axe: 0, pick: 0, hammer: 0, ammo: 0 })
                continue;
            if (Sets.Deprecated[item.type])
                continue;
            if (PHWeapons.Contains(i) || HMWeapons.Contains(i) || PostMLWeapons.Contains(i))
                continue;
            Console.WriteLine($"Missing weapon: {item.Name} ({i})");
        }
        */
    }
    public override void HandlePacket(BinaryReader reader, int whoAmI)
    {
        var plr = reader.ReadByte();
        var idAndMax = reader.ReadUInt16();

        var id = idAndMax >> 1;
        var max = (idAndMax & 0b1) != 0;

        var player = Main.player[plr];
        var item = player.inventory[0];
        item.SetDefaults(id);
        FullySetupItem(item, max);

        player.GetModPlayer<WeaponRandPlayer>().RandomizedEffect();

        if (Main.dedServ)
        {
            var p = GetPacket(3);
            p.Write(plr);
            p.Write(idAndMax);
            p.Send(ignoreClient: plr);
        }
    }
    public static void FullySetupItem(Item i, bool max)
    {
        if (max)
            i.stack = i.maxStack;
        if (ModLoader.HasMod("CalamityMod"))
            SetMaxCharge(i);
    }
}

public sealed class WeaponRandPlayer : ModPlayer
{
    internal static int Interval;
    private static int Timer;
    public bool TryKillHeldItem;
    public override void PreUpdate()
    {
        if (Player.whoAmI != Main.myPlayer)
            return;
        if (!WeaponRandConfig.Instance.Active)
        {
            Timer = 0;
            return;
        }
        if (++Timer > Interval)
        {
            Timer = 0;
            RandomizeItem();
        }
    }
    public void RandomizedEffect()
    {
        WeaponRandSystem.PollPlayerHeldProjectiles = TryKillHeldItem = true;
        if (WeaponRandConfig.Instance.ShowRandomizedEffect)
            CombatText.NewText(Player.Hitbox, Main.DiscoColor, Mod.GetLocalization("Common.RandomMessage").Value, true);
    }
    public void RandomizeItem()
    {
        var item = Player.inventory[0];
        RandomizeByProgression(item);
        RandomizedEffect();
        if (Main.netMode == NetmodeID.MultiplayerClient)
        {
            var p = WeaponRand.Instance.GetPacket(3);
            p.Write((byte)Player.whoAmI);
            var idAndMax = (uint)item.type << 1;
            if (WeaponRandConfig.Instance.MaxStack)
                idAndMax |= 0b1;
            p.Write((ushort)idAndMax);
            p.Send();
        }
    }
    public static void RandomizeByProgression(Item i)
    {
        DecideSet(out var primary, out var secondary);
        var count =  primary.Count + (secondary?.Count ?? 0);
        var choice = RandomNumberGenerator.GetInt32(count); // cuz we want super cool randomness or smth
        var randomType = choice >= primary.Count ? secondary[choice - primary.Count] : primary[choice];
        i.SetDefaults(randomType);
        WeaponRand.FullySetupItem(i, WeaponRandConfig.Instance.MaxStack);
    }
    public static void DecideSet(out List<short> primary, out List<short> secondary)
    {
        secondary = null;

        if (NPC.downedMoonlord)
        {
            if (WeaponRandConfig.Instance.PostDoGCategory && ModLoader.HasMod("CalamityMod"))
            {
                if (DownedDoG)
                {
                    primary = WeaponRand.PostDoGWeapons;
                    return;
                }
                primary = WeaponRand.PostMLWeapons;
                return;
            }
            primary = WeaponRand.PostMLWeapons;
            secondary = WeaponRand.PostDoGWeapons;
            return;
        }
        primary = Main.hardMode ? WeaponRand.HMWeapons : WeaponRand.PHWeapons;
    }
    [JITWhenModsEnabled("CalamityMod")]
    public static bool DownedDoG => DownedBossSystem.downedDoG;
}

public sealed class WeaponRandSystem : ModSystem
{
    internal static bool PollPlayerHeldProjectiles;
    public override void PostUpdateItems()
    {
        if (!PollPlayerHeldProjectiles)
            return;
        foreach (var player in Main.ActivePlayers)
        {
            ref var killHeldItem = ref player.GetModPlayer<WeaponRandPlayer>().TryKillHeldItem;

            if (killHeldItem)
            {
                // kill the current held projectile and reset the player's item time
                ref var hp = ref player.heldProj;
                if (hp != -1)
                {
                    Main.projectile[hp].Kill();
                    hp = -1;
                    player.SetItemTime(0);
                    player.SetItemAnimation(0);
                }
                killHeldItem = false;
            }

            if (ModLoader.HasMod("CalamityMod"))
                KillCalamAttachments(player);
        }
        PollPlayerHeldProjectiles = false;
    }

    [JITWhenModsEnabled("CalamityMod")]
    public static void KillCalamAttachments(Player p)
    {
        var robot = ModContent.ProjectileType<GiantIbanRobotOfDoom>();
        if (p.ownedProjectileCounts[robot] != 0)
        {
            foreach (var proj in Main.ActiveProjectiles)
            {
                if (proj.type == robot && proj.owner == p.whoAmI)
                    proj.Kill();
            }
        }
    }
}

public sealed class WeaponRandConfig : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ClientSide;

    public static WeaponRandConfig Instance;

    [Header("Randomizer")]

    [DefaultValue(true)]
    public bool Active;

    [DefaultValue(true)]
    public bool PostDoGCategory;

    [Header("Interval")]

    [Range(0, 999), DefaultValue(0), Increment(3), Slider]
    public int Milliseconds;

    [Range(0, 59), DefaultValue(0), Slider]
    public int Seconds;

    [Range(0, 5), DefaultValue(1), Slider]
    public int Minutes;

    [Header("Other")]

    [DefaultValue(true)]
    public bool MaxStack;

    [DefaultValue(true)]
    public bool ShowRandomizedEffect;

    public override void OnChanged()
    {
        WeaponRandPlayer.Interval = ((Minutes * 60 + Seconds) * 60) + ((int)Math.Ceiling(Milliseconds / (50d / 3d)));
    }
}

public static class Utilities
{
    public static bool IsWeapon(this Item i) => i is { damage: > -1, axe: 0, pick: 0, hammer: 0 } && (i.ammo == 0 || i.shoot != ProjectileID.None);
}
