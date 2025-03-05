#!/bin/bash

# CHAOTIC SLOT DUNGEON CRAWLER INSTALLER AND LAUNCHER
# THIS SCRIPT IS A DISASTER AND WE LOVE IT

echo "🔥🔥🔥 PREPARING TO UNLEASH MAXIMUM CHAOS 🔥🔥🔥"
sleep 1

# Fancy terminal output because WHY NOT
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
MAGENTA='\033[0;35m'
CYAN='\033[0;36m'
NC='\033[0m' # No Color

# RANDOMLY COLOR EVERYTHING BECAUSE CHAOS
function random_color {
    COLORS=("$RED" "$GREEN" "$YELLOW" "$BLUE" "$MAGENTA" "$CYAN")
    echo "${COLORS[$RANDOM % ${#COLORS[@]}]}"
}

function print_chaos {
    COLOR=$(random_color)
    echo -e "${COLOR}$1${NC}"
    sleep 0.3
}

# CHECK FOR .NET BUT IN THE MOST CHAOTIC WAY POSSIBLE
print_chaos "⚙️ CHECKING IF .NET EXISTS IN THIS DIMENSION ⚙️"
sleep 1

if ! command -v dotnet &> /dev/null; then
    print_chaos "❌ DOTNET NOT FOUND! CIVILIZATION IS DOOMED! ❌"
    print_chaos "ATTEMPTING TO SUMMON .NET FROM THE VOID..."
    
    # Determine the OS in a chaotic way
    OS_TYPE=$(uname -s | tr '[:upper:]' '[:lower:]' | rev | tr 'aeiou' 'AEIOU' | rev)
    
    if [[ "$OS_TYPE" == *"dArwIn"* ]]; then
        print_chaos "mAcOS dEtEcTeD! ThE aPpLe LuRkS!"
        print_chaos "YOU NEED TO INSTALL .NET 9 FROM:"
        print_chaos "https://dotnet.microsoft.com/download/dotnet/9.0"
    elif [[ "$OS_TYPE" == *"lInUx"* ]]; then
        print_chaos "LINUX DETECTED - YOU ARE A PERSON OF CULTURE AND CHAOS"
        print_chaos "MAYBE TRY: sudo apt install dotnet-sdk-9.0 -y || sudo pacman -S dotnet-sdk || dnf install dotnet || snap install dotnet-sdk"
    else
        print_chaos "WHAT EVEN IS THIS OPERATING SYSTEM?! THE VOID BECKONS!"
    fi
    
    print_chaos "INSTALL .NET 9 AND RETURN WHEN YOU ARE WORTHY!"
    exit 1
else
    DOTNET_VERSION=$(dotnet --version)
    print_chaos "🎉 DOTNET DETECTED! VERSION: $DOTNET_VERSION 🎉"
    
    if [[ "$DOTNET_VERSION" != 9* ]]; then
        print_chaos "⚠️⚠️⚠️ WARNING: YOU ARE NOT RUNNING .NET 9 ⚠️⚠️⚠️"
        print_chaos "CHAOS LEVELS MAY BE SUBOPTIMAL"
        print_chaos "DO YOU DARE CONTINUE ANYWAY? (y/n)"
        read -n 1 -r
        echo
        if [[ ! $REPLY =~ ^[Yy]$ ]]; then
            print_chaos "WISE CHOICE. RETURN WHEN YOU HAVE EMBRACED .NET 9!"
            exit 1
        fi
        print_chaos "BRAVE BUT FOOLISH! ATTEMPTING TO PROCEED WITH INFERIOR .NET VERSION..."
        sleep 1
    fi
fi

# BUILD THE PROJECT BUT MAKE IT WEIRD
print_chaos "🔨 ASSEMBLING THE CHAOS ENGINE 🔨"
print_chaos "COMPILING WITH EXTRA RANDOMNESS..."

# Do an actual build but make it super weird
dotnet restore && print_chaos "DEPENDENCIES SUMMONED FROM THE VOID!" || print_chaos "DEPENDENCY SUMMON FAILED - CONTINUING ANYWAY BECAUSE CHAOS!"

# Add some fake compiler flags for fun
CHAOS_FLAGS=("--chaos-level=MAXIMUM" "--enable-bugs" "--suppress-sanity" "--unleash-the-kraken" "--yolo-mode")
RANDOM_FLAG=${CHAOS_FLAGS[$RANDOM % ${#CHAOS_FLAGS[@]}]}

print_chaos "USING SECRET COMPILER FLAG: $RANDOM_FLAG"
dotnet build || print_chaos "BUILD FAILING IS PART OF THE EXPERIENCE!"

# RUN THE GAME WITH MAXIMUM INSANITY
print_chaos ""
print_chaos "⚡⚡⚡ BRACE YOURSELF FOR CHAOS ⚡⚡⚡"
print_chaos "LAUNCHING INTO THE ABYSS IN..."
print_chaos "3..."
sleep 1
print_chaos "2..."
sleep 1
print_chaos "1..."
sleep 1
print_chaos "MAY GOD HAVE MERCY ON YOUR CODEBASE!"

# Actually run the program
echo -e "${MAGENTA}"
dotnet run
echo -e "${NC}"

print_chaos "IF YOU SURVIVED, CONGRATULATIONS! YOUR SANITY DIDN'T!" 