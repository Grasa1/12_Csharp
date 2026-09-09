using System;
using System.Threading;

class Program
{
    // ==========================================
    // PLAYER
    // ==========================================

    static int playerHP = 100;
    static int maxPlayerHP = 100;

    static int playerMana = 100;
    static int maxPlayerMana = 100;

    // ==========================================
    // BOSS
    // ==========================================

    static int bossHP = 300;
    static int maxBossHP = 300;

    // ==========================================
    // EFFECTEK
    // ==========================================

    static int burnTurns = 0;
    static int poisonTurns = 0;
    static int shockTurns = 0;
    static int freezeTurns = 0;
    static int armorBreakTurns = 0;
    static int stormTurns = 0;

    static bool shieldActive = false;

    static int turn = 1;

    static Random random = new Random();

    // ==========================================
    // MAIN
    // ==========================================

    static void Main()
    {
        Console.Title = "Mage vs Ancient Boss";

        while (playerHP > 0 && bossHP > 0)
        {
            Console.Clear();

            DrawGame();

            Console.WriteLine();
            DrawSpells();

            Console.WriteLine();
            Console.Write("Válassz egy képességet: ");

            ConsoleKey key = Console.ReadKey(true).Key;

            bool spellUsed = PlayerTurn(key);

            if (!spellUsed)
                continue;

            if (bossHP <= 0)
                break;

            Console.WriteLine();

            // Effektjeink a kör végén
            ProcessBossEffects();

            if (bossHP <= 0)
                break;

            Console.WriteLine();
            Console.WriteLine("A boss következik...");
            Thread.Sleep(1000);

            BossTurn();

            if (playerHP <= 0)
                break;

            // Mana kis visszatöltése minden körben
            playerMana += 10;

            if (playerMana > maxPlayerMana)
                playerMana = maxPlayerMana;

            turn++;

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Nyomj meg egy gombot a következő körhöz...");
            Console.ResetColor();

            Console.ReadKey(true);
        }

        EndGame();
    }

    // ==========================================
    // SPELL LISTA
    // ==========================================

    static void DrawSpells()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("========== SPELLS ==========");
        Console.ResetColor();

        Console.WriteLine();

        Console.WriteLine("[1] 🔥 Fireball");
        Console.WriteLine("    25 DMG | 15 Mana | Burn 2 kör");

        Console.WriteLine();

        Console.WriteLine("[2] ⚡ Lightning");
        Console.WriteLine("    35 DMG | 25 Mana | Shock");

        Console.WriteLine();

        Console.WriteLine("[3] ❄ Ice Blast");
        Console.WriteLine("    20 DMG | 20 Mana | Freeze");

        Console.WriteLine();

        Console.WriteLine("[4] ☄ Meteor");
        Console.WriteLine("    50 DMG | 40 Mana");

        Console.WriteLine();

        Console.WriteLine("[5] ☠ Poison Bolt");
        Console.WriteLine("    15 DMG | 20 Mana | Poison 3 kör");

        Console.WriteLine();

        Console.WriteLine("[6] 🗡 Arcane Strike");
        Console.WriteLine("    18 DMG | 10 Mana | Armor Break");

        Console.WriteLine();

        Console.WriteLine("[7] 🌪 Arcane Storm");
        Console.WriteLine("    12 DMG | 30 Mana | 3 kör");

        Console.WriteLine();

        Console.WriteLine("[Q] 🛡 Magic Shield");
        Console.WriteLine("    20 Mana | Következő támadás -60%");

        Console.WriteLine();

        Console.WriteLine("[E] 💚 Heal");
        Console.WriteLine("    +40 HP | 25 Mana");

        Console.WriteLine();

        Console.WriteLine("[R] 🔮 Mana Surge");
        Console.WriteLine("    +35 Mana");
    }

    // ==========================================
    // PLAYER TURN
    // ==========================================

    static bool PlayerTurn(ConsoleKey key)
    {
        switch (key)
        {
            // FIREBALL
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:

                if (!UseMana(15))
                    return false;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n🔥 FIREBALL!");
                Console.ResetColor();

                BossDamage(25);

                burnTurns = 2;

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("🔥 A boss égni kezd! 2 körig Burn!");
                Console.ResetColor();

                break;

            // LIGHTNING
            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:

                if (!UseMana(25))
                    return false;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n⚡ LIGHTNING!");
                Console.ResetColor();

                BossDamage(35);

                shockTurns = 1;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("⚡ A boss Shock állapotba került!");
                Console.WriteLine("A következő körben extra sebzést kap.");
                Console.ResetColor();

                break;

            // ICE
            case ConsoleKey.D3:
            case ConsoleKey.NumPad3:

                if (!UseMana(20))
                    return false;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n❄ ICE BLAST!");
                Console.ResetColor();

                BossDamage(20);

                freezeTurns = 1;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("❄ A boss megfagyott!");
                Console.WriteLine("A következő támadása 50%-kal gyengébb.");
                Console.ResetColor();

                break;

            // METEOR
            case ConsoleKey.D4:
            case ConsoleKey.NumPad4:

                if (!UseMana(40))
                    return false;

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n☄ METEOR!");
                Console.ResetColor();

                BossDamage(50);

                break;

            // POISON
            case ConsoleKey.D5:
            case ConsoleKey.NumPad5:

                if (!UseMana(20))
                    return false;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n☠ POISON BOLT!");
                Console.ResetColor();

                BossDamage(15);

                poisonTurns = 3;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("☠ A boss megmérgeződött!");
                Console.WriteLine("3 körig mérgezés sebzi.");
                Console.ResetColor();

                break;

            // ARCANE STRIKE
            case ConsoleKey.D6:
            case ConsoleKey.NumPad6:

                if (!UseMana(10))
                    return false;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n🗡 ARCANE STRIKE!");
                Console.ResetColor();

                BossDamage(18);

                armorBreakTurns = 2;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("🗡 Armor Break!");
                Console.WriteLine("A boss 2 körig több sebzést kap.");
                Console.ResetColor();

                break;

            // ARCANE STORM
            case ConsoleKey.D7:
            case ConsoleKey.NumPad7:

                if (!UseMana(30))
                    return false;

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n🌪 ARCANE STORM!");
                Console.ResetColor();

                BossDamage(12);

                stormTurns = 3;

                Console.WriteLine("🌪 Arcane Storm aktív! 3 körig extra sebzés.");

                break;

            // SHIELD
            case ConsoleKey.Q:

                if (!UseMana(20))
                    return false;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n🛡 MAGIC SHIELD!");
                Console.ResetColor();

                shieldActive = true;

                Console.WriteLine("A következő boss támadás 60%-kal gyengébb!");

                break;

            // HEAL
            case ConsoleKey.E:

                if (!UseMana(25))
                    return false;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n💚 HEAL!");
                Console.ResetColor();

                int oldHP = playerHP;

                playerHP += 40;

                if (playerHP > maxPlayerHP)
                    playerHP = maxPlayerHP;

                Console.WriteLine(
                    $"💚 +{playerHP - oldHP} HP"
                );

                break;

            // MANA
            case ConsoleKey.R:

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n🔮 MANA SURGE!");
                Console.ResetColor();

                int oldMana = playerMana;

                playerMana += 35;

                if (playerMana > maxPlayerMana)
                    playerMana = maxPlayerMana;

                Console.WriteLine(
                    $"🔮 +{playerMana - oldMana} Mana"
                );

                break;

            default:

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nIsmeretlen képesség!");
                Console.ResetColor();

                return false;
        }

        Thread.Sleep(700);

        return true;
    }

    // ==========================================
    // MANA
    // ==========================================

    static bool UseMana(int amount)
    {
        if (playerMana < amount)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n❌ Nincs elég manád!");
            Console.ResetColor();

            return false;
        }

        playerMana -= amount;

        return true;
    }

    // ==========================================
    // BOSS DAMAGE
    // ==========================================

    static void BossDamage(int damage)
    {
        if (armorBreakTurns > 0)
        {
            damage = (int)(damage * 1.25);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("🗡 Armor Break miatt extra sebzés!");
            Console.ResetColor();
        }

        int oldHP = bossHP;

        bossHP -= damage;

        if (bossHP < 0)
            bossHP = 0;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"💥 A boss {damage} sebzést kapott!");
        Console.ResetColor();

        AnimateHP(oldHP, bossHP, true);
    }

    // ==========================================
    // BOSS EFFECTEK
    // ==========================================

    static void ProcessBossEffects()
    {
        // BURN
        if (burnTurns > 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n🔥 BURN!");

            BossDamage(8);

            Console.WriteLine("A tűz 8 sebzést okozott.");

            Console.ResetColor();

            burnTurns--;
        }

        // POISON
        if (poisonTurns > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n☠ POISON!");

            BossDamage(6);

            Console.WriteLine("A méreg 6 sebzést okozott.");

            Console.ResetColor();

            poisonTurns--;
        }

        // SHOCK
        if (shockTurns > 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n⚡ SHOCK!");

            BossDamage(12);

            Console.WriteLine("A villám 12 extra sebzést okozott.");

            Console.ResetColor();

            shockTurns--;
        }

        // STORM
        if (stormTurns > 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n🌪 ARCANE STORM!");

            BossDamage(10);

            Console.WriteLine("A vihar 10 extra sebzést okozott.");

            Console.ResetColor();

            stormTurns--;
        }

        if (armorBreakTurns > 0)
            armorBreakTurns--;
    }

    // ==========================================
    // BOSS TURN
    // ==========================================

    static void BossTurn()
    {
        int attack = random.Next(0, 4);

        int damage;

        switch (attack)
        {
            case 0:

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n👹 SHADOW STRIKE!");
                Console.ResetColor();

                damage = random.Next(15, 26);

                break;

            case 1:

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n🔥 INFERNO!");
                Console.ResetColor();

                damage = random.Next(20, 31);

                break;

            case 2:

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n💀 SOUL CRUSH!");
                Console.ResetColor();

                damage = random.Next(25, 36);

                break;

            default:

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n⚔ DARK SLASH!");
                Console.ResetColor();

                damage = random.Next(10, 21);

                break;
        }

        // FREEZE
        if (freezeTurns > 0)
        {
            damage /= 2;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("❄ A Freeze miatt a boss támadása gyengébb!");
            Console.ResetColor();

            freezeTurns--;
        }

        // SHIELD
        if (shieldActive)
        {
            damage = (int)(damage * 0.4);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("🛡 MAGIC SHIELD blokkolta a sebzés nagy részét!");
            Console.ResetColor();

            shieldActive = false;
        }

        int oldHP = playerHP;

        playerHP -= damage;

        if (playerHP < 0)
            playerHP = 0;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"👹 A boss {damage} sebzést okozott!");
        Console.ResetColor();

        AnimateHP(oldHP, playerHP, false);
    }

    // ==========================================
    // GAME UI
    // ==========================================

    static void DrawGame()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║          ⚔ MAGE VS ANCIENT BOSS ⚔       ║");
        Console.WriteLine("╚══════════════════════════════════════════╝");

        Console.ResetColor();

        Console.WriteLine();

        Console.WriteLine($"KÖR: {turn}");

        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("👹 BOSS");
        Console.ResetColor();

        DrawBar(
            bossHP,
            maxBossHP,
            40,
            ConsoleColor.Red
        );

        Console.WriteLine($"{bossHP} / {maxBossHP} HP");

        DrawEffects();

        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🧙 MAGE");
        Console.ResetColor();

        DrawBar(
            playerHP,
            maxPlayerHP,
            40,
            ConsoleColor.Green
        );

        Console.WriteLine($"{playerHP} / {maxPlayerHP} HP");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine();

        Console.Write("🔮 MANA ");

        DrawBar(
            playerMana,
            maxPlayerMana,
            40,
            ConsoleColor.Blue
        );

        Console.ResetColor();

        Console.WriteLine($"{playerMana} / {maxPlayerMana}");
    }

    // ==========================================
    // EFFECT UI
    // ==========================================

    static void DrawEffects()
    {
        Console.WriteLine();

        if (burnTurns > 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"🔥 Burn ({burnTurns}) ");
        }

        if (poisonTurns > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"☠ Poison ({poisonTurns}) ");
        }

        if (shockTurns > 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"⚡ Shock ({shockTurns}) ");
        }

        if (freezeTurns > 0)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"❄ Freeze ({freezeTurns}) ");
        }

        if (armorBreakTurns > 0)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"🗡 Armor Break ({armorBreakTurns}) ");
        }

        if (stormTurns > 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"🌪 Storm ({stormTurns}) ");
        }

        Console.ResetColor();

        Console.WriteLine();
    }

    // ==========================================
    // HP BAR
    // ==========================================

    static void DrawBar(
        int current,
        int max,
        int length,
        ConsoleColor color)
    {
        double percentage = (double)current / max;

        int filled = (int)(percentage * length);

        Console.Write("[");

        Console.ForegroundColor = color;

        for (int i = 0; i < filled; i++)
            Console.Write("█");

        Console.ResetColor();

        for (int i = filled; i < length; i++)
            Console.Write("-");

        Console.Write("] ");

        Console.Write($"{percentage * 100:0}%");

        Console.WriteLine();
    }

    // ==========================================
    // HP ANIMÁCIÓ
    // ==========================================

    static void AnimateHP(
        int oldHP,
        int newHP,
        bool boss)
    {
        int hp = oldHP;

        while (hp > newHP)
        {
            hp -= 5;

            if (hp < newHP)
                hp = newHP;

            Console.Write("\r");

            if (boss)
                Console.Write($"👹 Boss HP: {hp}/{maxBossHP}   ");
            else
                Console.Write($"🧙 Player HP: {hp}/{maxPlayerHP}   ");

            Thread.Sleep(40);
        }

        Console.WriteLine();
    }

    // ==========================================
    // END GAME
    // ==========================================

    static void EndGame()
    {
        Console.Clear();

        if (playerHP <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("======================================");
            Console.WriteLine("              💀 DEFEAT");
            Console.WriteLine("======================================");

            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("A boss legyőzött téged...");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("======================================");
            Console.WriteLine("            🏆 VICTORY!");
            Console.WriteLine("======================================");

            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("Legyőzted az Ancient Bosst!");
        }

        Console.WriteLine();
        Console.WriteLine("Nyomj meg egy gombot...");
        Console.ReadKey();
    }
}
