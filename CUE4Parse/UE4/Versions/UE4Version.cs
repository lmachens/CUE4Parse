﻿using CUE4Parse.UE4.Assets.Readers;
using CUE4Parse.UE4.Objects.Core.Misc;
using CUE4Parse.UE4.Objects.UObject;
using System.Runtime.CompilerServices;

namespace CUE4Parse.UE4.Versions
{
    public static class VersionUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetUE4CustomVersion(FPackageFileSummary summary, FGuid guid)
        {
            for (int i = 0; i < summary.CustomContainerVersion.Length; i++)
            {
                if (summary.CustomContainerVersion[i].Key == guid)
                {
                    return summary.CustomContainerVersion[i].Version;
                }
            }
            return -1;
        }
    }

    // Unreal engine 4 versions, declared as enum to be able to see all revisions in a single place
    public enum UE4Version
    {
        // Pre-release UE4 file versions
        VER_UE4_ASSET_REGISTRY_TAGS = 112,
        VER_UE4_TEXTURE_DERIVED_DATA2 = 124,
        VER_UE4_ADD_COOKED_TO_TEXTURE2D = 125,
        VER_UE4_REMOVED_STRIP_DATA = 130,
        VER_UE4_REMOVE_EXTRA_SKELMESH_VERTEX_INFLUENCES = 134,
        VER_UE4_TEXTURE_SOURCE_ART_REFACTOR = 143,
        VER_UE4_ADD_SKELMESH_MESHTOIMPORTVERTEXMAP = 152,
        VER_UE4_REMOVE_ARCHETYPE_INDEX_FROM_LINKER_TABLES = 163,
        VER_UE4_REMOVE_NET_INDEX = 196,
        VER_UE4_BULKDATA_AT_LARGE_OFFSETS = 198,
        VER_UE4_SUMMARY_HAS_BULKDATA_OFFSET = 212,
        VER_UE4_STATIC_MESH_STORE_NAV_COLLISION = 216,
        VER_UE4_DEPRECATED_STATIC_MESH_THUMBNAIL_PROPERTIES_REMOVED = 242,
        VER_UE4_APEX_CLOTH = 254,
        VER_UE4_STATIC_SKELETAL_MESH_SERIALIZATION_FIX = 269,
        VER_UE4_SUPPORT_32BIT_STATIC_MESH_INDICES = 277,
        VER_UE4_APEX_CLOTH_LOD = 280,
        VAR_UE4_ARRAY_PROPERTY_INNER_TAGS = 282, // note: here's a typo in UE4 code - "VAR_" instead of "VER_"
        VER_UE4_KEEP_SKEL_MESH_INDEX_DATA = 283,
        VER_UE4_MOVE_SKELETALMESH_SHADOWCASTING = 302,
        VER_UE4_REFERENCE_SKELETON_REFACTOR = 310,
        VER_UE4_FIXUP_ROOTBONE_PARENT = 312,
        VER_UE4_FIX_ANIMATIONBASEPOSE_SERIALIZATION = 331,
        VER_UE4_SUPPORT_8_BONE_INFLUENCES_SKELETAL_MESHES = 332,
        VER_UE4_SUPPORT_GPUSKINNING_8_BONE_INFLUENCES = 334,
        VER_UE4_ANIM_SUPPORT_NONUNIFORM_SCALE_ANIMATION = 335,
        VER_UE4_ENGINE_VERSION_OBJECT = 336,
        VER_UE4_SKELETON_GUID_SERIALIZATION = 338,

        // UE4.0 source code was released on GitHub. Note: if we don't have any VER_UE4_...
        // values between two VER_UE4_xx constants, for instance, between VER_UE4_0 and VER_UE4_1,
        // it doesn't matter for this framework which version will be serialized serialized -
        // 4.0 or 4.1, because 4.1 has nothing new for supported object formats compared to 4.0.
        VER_UE4_0 = 342,
        VER_UE4_MORPHTARGET_CPU_TANGENTZDELTA_FORMATCHANGE = 348,
        VER_UE4_1 = 352,
        VER_UE4_2 = 363,
        VER_UE4_LOAD_FOR_EDITOR_GAME = 365,
        VER_UE4_FTEXT_HISTORY = 368, // used for UStaticMesh versioning
        VER_UE4_STORE_BONE_EXPORT_NAMES = 370,
        VER_UE4_3 = 382,
        VER_UE4_ADD_STRING_ASSET_REFERENCES_MAP = 384,
        VER_UE4_4 = 385,
        VER_UE4_SKELETON_ADD_SMARTNAMES = 388,
        VER_UE4_ADDED_CURRENCY_CODE_TO_FTEXT = 389,
        VER_UE4_ENUM_CLASS_SUPPORT = 390,
        VER_UE4_FIXUP_WIDGET_ANIMATION_CLASS = 391,
        VER_UE4_SOUND_COMPRESSION_TYPE_ADDED = 392,
        VER_UE4_AUTO_WELDING = 393,
        VER_UE4_RENAME_CROUCHMOVESCHARACTERDOWN = 394, // used for UStaticMesh versioning
        VER_UE4_LIGHTMAP_MESH_BUILD_SETTINGS = 395,
        VER_UE4_RENAME_SM3_TO_ES3_1 = 396,
        VER_UE4_DEPRECATE_UMG_STYLE_ASSETS = 397, // used for UStaticMesh versioning
        VER_UE4_POST_DUPLICATE_NODE_GUID = 398,
        VER_UE4_RENAME_CAMERA_COMPONENT_VIEW_ROTATION = 399,
        VER_UE4_CASE_PRESERVING_FNAME = 400,
        VER_UE4_5 = 401, // VER_UE4_RENAME_CAMERA_COMPONENT_CONTROL_ROTATION
        VER_UE4_FIX_REFRACTION_INPUT_MASKING = 402,
        VER_UE4_GLOBAL_EMITTER_SPAWN_RATE_SCALE = 403,
        VER_UE4_CLEAN_DESTRUCTIBLE_SETTINGS = 404,
        VER_UE4_CHARACTER_MOVEMENT_UPPER_IMPACT_BEHAVIOR = 405,
        VER_UE4_BP_MATH_VECTOR_EQUALITY_USES_EPSILON = 406,
        VER_UE4_FOLIAGE_STATIC_LIGHTING_SUPPORT = 407,
        VER_UE4_SLATE_COMPOSITE_FONTS = 408,
        VER_UE4_REMOVE_SAVEGAMESUMMARY = 409,
        VER_UE4_REMOVE_SKELETALMESH_COMPONENT_BODYSETUP_SERIALIZATION = 410,
        VER_UE4_SLATE_BULK_FONT_DATA = 411,
        VER_UE4_ADD_PROJECTILE_FRICTION_BEHAVIOR = 412,
        VER_UE4_6 = 413, // VER_UE4_MOVEMENTCOMPONENT_AXIS_SETTINGS
        VER_UE4_GRAPH_INTERACTIVE_COMMENTBUBBLES = 414,
        VER_UE4_LANDSCAPE_SERIALIZE_PHYSICS_MATERIALS = 415,
        VER_UE4_RENAME_WIDGET_VISIBILITY = 416, // used for UStaticMesh versioning
        VER_UE4_ANIMATION_ADD_TRACKCURVES = 417,
        VER_UE4_MONTAGE_BRANCHING_POINT_REMOVAL = 418,
        VER_UE4_BLUEPRINT_ENFORCE_CONST_IN_FUNCTION_OVERRIDES = 419,
        VER_UE4_ADD_PIVOT_TO_WIDGET_COMPONENT = 420, // :)
        VER_UE4_PAWN_AUTO_POSSESS_AI = 421,
        VER_UE4_FTEXT_HISTORY_DATE_TIMEZONE = 422,
        VER_UE4_SORT_ACTIVE_BONE_INDICES = 423,
        VER_UE4_PERFRAME_MATERIAL_UNIFORM_EXPRESSIONS = 424,
        VER_UE4_MIKKTSPACE_IS_DEFAULT = 425,
        VER_UE4_LANDSCAPE_GRASS_COOKING = 426,
        VER_UE4_FIX_SKEL_VERT_ORIENT_MESH_PARTICLES = 427,
        VER_UE4_LANDSCAPE_STATIC_SECTION_OFFSET = 428,
        VER_UE4_ADD_MODIFIERS_RUNTIME_GENERATION = 429,
        VER_UE4_MATERIAL_MASKED_BLENDMODE_TIDY = 430,
        VER_UE4_MERGED_ADD_MODIFIERS_RUNTIME_GENERATION_TO_4_7_DEPRECATED = 431,
        VER_UE4_AFTER_MERGED_ADD_MODIFIERS_RUNTIME_GENERATION_TO_4_7_DEPRECATED = 432,
        VER_UE4_MERGED_ADD_MODIFIERS_RUNTIME_GENERATION_TO_4_7 = 433,
        VER_UE4_7 = 434, // VER_UE4_AFTER_MERGING_ADD_MODIFIERS_RUNTIME_GENERATION_TO_4_7
        VER_UE4_SERIALIZE_LANDSCAPE_GRASS_DATA = 435,
        VER_UE4_OPTIONALLY_CLEAR_GPU_EMITTERS_ON_INIT = 436,
        VER_UE4_STRUCT_GUID_IN_PROPERTY_TAG = 441,
        VER_UE4_PACKAGE_SUMMARY_HAS_COMPATIBLE_ENGINE_VERSION = 444,
        VER_UE4_8 = 451,
        VER_UE4_SERIALIZE_TEXT_IN_PACKAGES = 459,
        VER_UE4_9 = 482,
        VER_UE4_10 = VER_UE4_9, // exactly the same file version for 4.9 and 4.10
        VER_UE4_COOKED_ASSETS_IN_EDITOR_SUPPORT = 485,
        VER_UE4_SOUND_CONCURRENCY_PACKAGE = 489, // used for UStaticMesh versioning
        VER_UE4_11 = 498,
        VER_UE4_INNER_ARRAY_TAG_INFO = 500,
        VER_UE4_PROPERTY_GUID_IN_PROPERTY_TAG = 503,
        VER_UE4_NAME_HASHES_SERIALIZED = 504,
        VER_UE4_12 = 504,
        VER_UE4_13 = 505,
        VER_UE4_PRELOAD_DEPENDENCIES_IN_COOKED_EXPORTS = 507,
        VER_UE4_TemplateIndex_IN_COOKED_EXPORTS = 508,
        VER_UE4_14 = 508,
        VER_UE4_PROPERTY_TAG_SET_MAP_SUPPORT = 509,
        VER_UE4_ADDED_SEARCHABLE_NAMES = 510,
        VER_UE4_15 = 510,
        VER_UE4_64BIT_EXPORTMAP_SERIALSIZES = 511,
        VER_UE4_16 = 513,
        VER_UE4_17 = 513,
        VER_UE4_ADDED_SOFT_OBJECT_PATH = 514,
        VER_UE4_18 = 514,
        VER_UE4_ADDED_PACKAGE_SUMMARY_LOCALIZATION_ID = 516,
        VER_UE4_19 = 516,
        VER_UE4_20 = 516,
        VER_UE4_21 = 517,
        VER_UE4_22 = 517,
        VER_UE4_23 = 517,
        VER_UE4_ADDED_PACKAGE_OWNER = 518,
        VER_UE4_24 = 518,
        VER_UE4_25 = 518,
        VER_UE4_SKINWEIGHT_PROFILE_DATA_LAYOUT_CHANGES = 519,
        VER_UE4_26 = 519, //?? todo: review later
        //Add new ones here
        VER_UE4_LAST,
        VER_UE4_LATEST = VER_UE4_LAST - 1
    }

    public static class FFrameworkObjectVersion
    {
        public enum Type
        {
            BeforeCustomVersionWasAdded = 0,
            UseBodySetupCollisionProfile,
            AnimBlueprintSubgraphFix,
            MeshSocketScaleUtilization,
            ExplicitAttachmentRules,
            MoveCompressedAnimDataToTheDDC,
            FixNonTransactionalPins,
            SmartNameRefactor,
            AddSourceReferenceSkeletonToRig,
            ConstraintInstanceBehaviorParameters,
            PoseAssetSupportPerBoneMask,
            PhysAssetUseSkeletalBodySetup,
            RemoveSoundWaveCompressionName,
            AddInternalClothingGraphicalSkinning,
            WheelOffsetIsFromWheel,
            MoveCurveTypesToSkeleton,
            CacheDestructibleOverlaps,
            GeometryCacheMissingMaterials,
            LODsUseResolutionIndependentScreenSize,
            BlendSpacePostLoadSnapToGrid,
            SupportBlendSpaceRateScale,
            LODHysteresisUseResolutionIndependentScreenSize,
            ChangeAudioComponentOverrideSubtitlePriorityDefault,
            HardSoundReferences,
            EnforceConstInAnimBlueprintFunctionGraphs,
            InputKeySelectorTextStyle,
            EdGraphPinContainerType,
            ChangeAssetPinsToString,
            LocalVariablesBlueprintVisible,
            RemoveUField_Next,
            UserDefinedStructsBlueprintVisible,
            PinsStoreFName,
            UserDefinedStructsStoreDefaultInstance,
            FunctionTerminatorNodesUseMemberReference,
            EditableEventsUseConstRefParameters,
            BlueprintGeneratedClassIsAlwaysAuthoritative,
            EnforceBlueprintFunctionVisibility,
            StoringUCSSerializationIndex,
            VersionPlusOne,
            LatestVersion = VersionPlusOne - 1,
        };

        public static readonly FGuid GUID = new FGuid(0xCFFC743F, 0x43B04480, 0x939114DF, 0x171D2073);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type Get(FAssetArchive Ar)
        {
            int ver = VersionUtils.GetUE4CustomVersion(Ar.Owner.Summary, GUID);
            if (ver >= 0)
                return (Type)ver;

            if (Ar.Game < EGame.GAME_UE4_12)
                return Type.BeforeCustomVersionWasAdded;
            if (Ar.Game < EGame.GAME_UE4_13)
                return (Type)6;
            if (Ar.Game < EGame.GAME_UE4_14)
                return Type.RemoveSoundWaveCompressionName;
            if (Ar.Game < EGame.GAME_UE4_15)
                return Type.GeometryCacheMissingMaterials;
            if (Ar.Game < EGame.GAME_UE4_16)
                return (Type)22;
            if (Ar.Game < EGame.GAME_UE4_17)
                return (Type)23;
            if (Ar.Game < EGame.GAME_UE4_18)
                return (Type)28;
            if (Ar.Game < EGame.GAME_UE4_19)
                return (Type)30;
            if (Ar.Game < EGame.GAME_UE4_20)
                return (Type)33;
            if (Ar.Game < EGame.GAME_UE4_22)
                return (Type)34;
            if (Ar.Game < EGame.GAME_UE4_24)
                return (Type)35;
            if (Ar.Game < EGame.GAME_UE4_25)
                return (Type)36;
            if (Ar.Game < EGame.GAME_UE4_26)
                return (Type)37;

            return Type.LatestVersion;
        }
    }

    public static class FAnimPhysObjectVersion
    {
        public enum Type
        {
            BeforeCustomVersionWasAdded,
            ConvertAnimNodeLookAtAxis,
            BoxSphylElemsUseRotators,
            ThumbnailSceneInfoAndAssetImportDataAreTransactional,
            AddedClothingMaskWorkflow,
            RemoveUIDFromSmartNameSerialize,
            CreateTargetReference,
            TuneSoftLimitStiffnessAndDamping,
            FixInvalidClothParticleMasses,
            CacheClothMeshInfluences,
            SmartNameRefactorForDeterministicCooking,
            RenameDisableAnimCurvesToAllowAnimCurveEvaluation,
            AddLODToCurveMetaData,
            FixupBadBlendProfileReferences,
            AllowMultipleAudioPluginSettings,
            ChangeRetargetSourceReferenceToSoftObjectPtr,
            SaveEditorOnlyFullPoseForPoseAsset,
            GeometryCacheAssetDeprecation,
            VersionPlusOne,
            LatestVersion = VersionPlusOne - 1,
        };

        public static readonly FGuid GUID = new FGuid(0x29E575DD, 0xE0A34627, 0x9D10D276, 0x232CDCEA);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type Get(FAssetArchive Ar)
        {

            int ver = VersionUtils.GetUE4CustomVersion(Ar.Owner.Summary, GUID);
            if (ver >= 0)
                return (Type)ver;

            if (Ar.Game < EGame.GAME_UE4_16)
                return Type.BeforeCustomVersionWasAdded;
            if (Ar.Game < EGame.GAME_UE4_17)
                return (Type)3;
            if (Ar.Game < EGame.GAME_UE4_18)
                return (Type)7;
            if (Ar.Game < EGame.GAME_UE4_19)
                return Type.AddLODToCurveMetaData;
            if (Ar.Game < EGame.GAME_UE4_20)
                return (Type)16;
            if (Ar.Game < EGame.GAME_UE4_26)
                return (Type)17;

            return Type.LatestVersion;
        }
    }

    public static class FAnimObjectVersion
    {
        public enum Type
        {
            BeforeCustomVersionWasAdded,
            LinkTimeAnimBlueprintRootDiscovery,
            StoreMarkerNamesOnSkeleton,
            SerializeRigVMRegisterArrayState,
            IncreaseBoneIndexLimitPerChunk,
            UnlimitedBoneInfluences,
            AnimSequenceCurveColors,
            NotifyAndSyncMarkerGuids,
            VersionPlusOne,
            LatestVersion = VersionPlusOne - 1,
        };

        public static readonly FGuid GUID = new FGuid(0xAF43A65D, 0x7FD34947, 0x98733E8E, 0xD9C1BB05);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type Get(FAssetArchive Ar)
        {

            int ver = VersionUtils.GetUE4CustomVersion(Ar.Owner.Summary, GUID);
            if (ver >= 0)
                return (Type)ver;

            if (Ar.Game < EGame.GAME_UE4_21)
                return Type.BeforeCustomVersionWasAdded;
            if (Ar.Game < EGame.GAME_UE4_25)
                return Type.StoreMarkerNamesOnSkeleton;
            if (Ar.Game < EGame.GAME_UE4_26)
                return (Type)7;

            return Type.LatestVersion;
        }
    }
}