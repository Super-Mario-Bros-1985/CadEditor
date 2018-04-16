from shutil import copyfile
import os

GoodNesPath = r"d:\ROM\Dendy\GoodNES3.1\best"

fnames = [
    "Abadox - The Deadly Inner War (U) [!].nes",
    "Addams Family, The (E) [!].nes",
    "Addams Family, The - Pugsley's Scavenger Hunt (U) [!p].nes",
    "Adventures in the Magic Kingdom (U) [!].nes",
    "Aladdin 4 (1996) (Unl) [!].nes",
    "Alien 3 (U) [!].nes",
    "Batman (U) [!].nes",
    "Batman III [p1].nes",
    "Battletoads & Double Dragon - The Ultimate Team (E) [!p].nes",
    "Battletoads (U) [!].nes",
    "Banana Prince (G) [!].nes",
    "Bucky O'Hare (E).nes",
    "Captain America and The Avengers (U) [!].nes",
    "Captain Planet and The Planeteers (U) [!].nes",
    "Castlevania (E).nes",
    "Challenger (J).nes",
    "Cheetah Men II (U) [!p].nes",
    "Chip 'n Dale Rescue Rangers (U) [!].nes",
    "Chip 'n Dale Rescue Rangers 2 (U) [!].nes",
    "Circus Caper (U) [!].nes",
    "Contra Force (U) [!].nes",
    "Contra Spirits (1995) (Unl).nes",
    "Crystal Mines (Unl) [!p].nes",
    "Darkman (U) [!].nes",
    "Darkwing Duck (U) [!].nes",
    "Donkey Kong Country 4 (Unl) [!].nes",
    "Dragon Fighter (U) [!].nes",
    "Duck Tales (U) [!].nes",
    "Duck Tales 2 (U) [!].nes",
    "EarthWorm Jim 3 (Unl) [!].nes",
    "Felix the Cat (U) [!].nes",
    "Final Fight 3 (Unl) [!].nes",
    "Final Mission (J) [!].nes",
    "Flintstones, The - The Rescue of Dino & Hoppy (U) [!].nes",
    "Flintstones, The - The Surprise at Dinosaur Peak! (U) [!p].nes",
    "Ghosts 'N Goblins (U) [!].nes",
    "Goonies II, The (U) [!].nes",
    "Gun.Smoke (U) [!].nes",
    "Harry's Legend (English) (Unl).nes",
    "Hook (U) [!].nes",
    "Hudson's Adventure Island II (U) [!].nes",
    "Hudson's Adventure Island III (U) [!].nes",
    "Jackal (U) [!].nes",
    "Jackie Chan's Action Kung Fu (U) [!p].nes",
    "Jungle Book, The (U) [!].nes",
    "Jurassic Park (U) [!].nes",
    "Kyatto Ninja Teyandee (J).nes",
    "Little Mermaid, The (U) [!].nes",
    "Little Nemo - The Dream Master (U) [!].nes",
    "Little Samson (U) [!p].nes",
    "Low G Man - The Low Gravity Man (U) [!].nes",
    "Mappy Kids (J).nes",
    "Megaman (U) [!].nes",
    "Megaman II (U) [!].nes",
    "Megaman III (U) [!].nes",
    "Megaman IV (U) (PRG0) [!].nes",
    "Megaman V (E) [!].nes",
    "Mickey Mania 7 (Unl) [!].nes",
    "Mickey Mouse 3 - Yume Fuusen (J).nes",
    "Mickey Mousecapade (U) [!].nes",
    "Mickey's Adventures in Numberland (U) [!p].nes",
    "Micro Machines (Unl) [!].nes",
    "Mighty Final Fight (U) [!p].nes",
    "Mission - Impossible (U) [!].nes",
    "Mitsume ga Tooru (J).nes",
    "Monster In My Pocket (U) [!].nes",
    "Moon Crystal (J) [!].nes",
    "New Ghostbusters II (E) [!].nes",
    "Ninja Crusaders (U) [!p].nes",
    "Ninja Gaiden (U) [!].nes",
    "Ninja Gaiden II - The Dark Sword of Chaos (U) [!].nes",
    "Ninja Gaiden III - The Ancient Ship of Doom (U) [!].nes",
    "Power Blade (E) [!].nes",
    "Power Blade 2 (U) [!].nes",
    "Predator (U) [!].nes",
    "Raf World (J).nes",
    "RoboCop 2 (U) (PRG1) [!].nes",
    "Rockin' Kats (U) [!].nes",
    "SD Hero Soukessen - Taose! Aku no Gundan (J) [!].nes",
    "Shadow of the Ninja (U) [!].nes",
    "Shatterhand (U) [!].nes",
    "Sonic The Hedgehog (Unl) [!].nes",
    "Super C (U) [!].nes",
    "Super Mario World (Unl).nes",
    "Super Robin Hood [p1][!].nes",
    "Super Spy Hunter (U) [!].nes",
    "TaleSpin (E) [!].nes",
    "Takeshi no Chousenjou (J).nes",
    "Teenage Mutant Ninja Turtles (U) [!].nes",
    "Teenage Mutant Ninja Turtles II - The Arcade Game (U) [!].nes",
    "Teenage Mutant Ninja Turtles III - The Manhattan Project (U) [!].nes",
    "Terminator 2 - Judgment Day (E) [!].nes",
    "Tiny Toon Adventures (U) [!].nes",
    "Tiny Toon Adventures 2 - Trouble in Wackyland (U) [!].nes",
    "Tiny Toon Adventures 6 (Unl) [!].nes",
    "Titenic (Unl) (As) [f1].nes",
    "Tom & Jerry (and Tuffy) (J).nes",
    "Toxic Crusaders (U) [!].nes",
    "Young Indiana Jones Chronicles, The (U) [!].nes",
    "Yo! Noid (U) [!].nes",
    "Zen Intergalactic Ninja (U) [!].nes"
]

for fname in fnames:
    copyfile(os.path.join(GoodNesPath, fname), fname)