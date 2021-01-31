/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_AMBIENCE_BACKGROUND_CAVERN = 1970585623U;
        static const AkUniqueID PLAY_AMBIENCE_WATER_WATERFALL = 2972937805U;
        static const AkUniqueID PLAY_BRASERO = 3518263358U;
        static const AkUniqueID PLAY_END_LEVEL_DOOR = 1152301005U;
        static const AkUniqueID PLAY_FOLEY = 3113720603U;
        static const AkUniqueID PLAY_FOOTSTEPS = 3854155799U;
        static const AkUniqueID PLAY_IMPACT_FLARE = 2389238889U;
        static const AkUniqueID PLAY_INTERACT = 3621663528U;
        static const AkUniqueID PLAY_MUSIC = 2932040671U;
        static const AkUniqueID PLAY_PICKUP_ITEM = 3128913152U;
        static const AkUniqueID PLAY_PLAYER_DEATH = 1835085974U;
        static const AkUniqueID PLAY_PLAYER_RESPAWN = 4238880044U;
        static const AkUniqueID PLAY_THROW_FLARE = 838326419U;
        static const AkUniqueID PLAY_TRAMPOLINE = 3799408143U;
        static const AkUniqueID PLAY_TURN_ON_BURN_FLARE = 3232459058U;
        static const AkUniqueID PLAY_UI_BACK = 1386224142U;
        static const AkUniqueID PLAY_UI_OVER = 3300168493U;
        static const AkUniqueID PLAY_UI_SELECT = 3308548503U;
        static const AkUniqueID STOP_AMBIENCE_BACKGROUND_CAVERN = 366309757U;
        static const AkUniqueID STOP_AMBIENCE_WATER_WATERFALL = 3894217275U;
        static const AkUniqueID STOP_BRASERO = 1873728636U;
        static const AkUniqueID STOP_BURNING_FLARE_FADEOUT = 3353542511U;
        static const AkUniqueID STOP_BURNING_FLARE_IMMEDIATE = 917084758U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace LEVEL_MUSIC
        {
            static const AkUniqueID GROUP = 1244594577U;

            namespace STATE
            {
                static const AkUniqueID MUSIC_ON_1LAYER = 1275403157U;
                static const AkUniqueID MUSIC_ON_2LAYERS = 103655667U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID SILENCE = 3041563226U;
            } // namespace STATE
        } // namespace LEVEL_MUSIC

    } // namespace STATES

    namespace SWITCHES
    {
        namespace MATERIAL_TYPE
        {
            static const AkUniqueID GROUP = 1097155889U;

            namespace SWITCH
            {
                static const AkUniqueID STONE = 1216965916U;
                static const AkUniqueID WATER = 2654748154U;
            } // namespace SWITCH
        } // namespace MATERIAL_TYPE

        namespace MOVEMENT_TYPE
        {
            static const AkUniqueID GROUP = 1088160865U;

            namespace SWITCH
            {
                static const AkUniqueID JUMP = 3833651337U;
                static const AkUniqueID LAND = 674522502U;
                static const AkUniqueID RUN = 712161704U;
            } // namespace SWITCH
        } // namespace MOVEMENT_TYPE

        namespace MUSIC
        {
            static const AkUniqueID GROUP = 3991942870U;

            namespace SWITCH
            {
                static const AkUniqueID END = 529726532U;
                static const AkUniqueID INTRO = 1125500713U;
                static const AkUniqueID LEVELS = 2678230316U;
            } // namespace SWITCH
        } // namespace MUSIC

    } // namespace SWITCHES

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID AMBIENCES = 1017660616U;
        static const AkUniqueID AUX = 983310469U;
        static const AkUniqueID CHARACTERS = 1557941045U;
        static const AkUniqueID FLARE = 1540219311U;
        static const AkUniqueID FOLEY = 247557814U;
        static const AkUniqueID FOOTSTEPS = 2385628198U;
        static const AkUniqueID ITEMS = 2151963051U;
        static const AkUniqueID LEVELS_THEME = 1651733522U;
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID NON_WORLD = 3869140995U;
        static const AkUniqueID PLAYER = 1069431850U;
        static const AkUniqueID SCREENTITLE_THEME = 1631542459U;
        static const AkUniqueID WORLD = 2609808943U;
    } // namespace BUSSES

    namespace AUX_BUSSES
    {
        static const AkUniqueID AUX_DEATH = 1236188118U;
        static const AkUniqueID AUX_RVB_CAVERN = 3352913298U;
    } // namespace AUX_BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
