using CUE4Parse.UE4.Objects.Core.Misc;
using CUE4Parse.UE4.Readers;

namespace CUE4Parse.UE4.Versions
{
    // Custom serialization version for changes made in the //Fortnite/Main stream
    public class FFortniteMainBranchObjectVersion
    {
        public enum Type
        {
            // Before any version changes were made
            BeforeCustomVersionWasAdded = 0,

            // World composition tile offset changed from 2d to 3d
            WorldCompositionTile3DOffset,

            // Minor material serialization optimization
            MaterialInstanceSerializeOptimization_ShaderFName,

            // Refactored cull distances to account for HLOD, explicit override and globals in priority
            CullDistanceRefactor_RemovedDefaultDistance,
            CullDistanceRefactor_NeverCullHLODsByDefault,
            CullDistanceRefactor_NeverCullALODActorsByDefault,

            // Support to remove morphtarget generated by bRemapMorphtarget
            SaveGeneratedMorphTargetByEngine,

            // Convert reduction setting options
            ConvertReductionSettingOptions,

            // Serialize the type of blending used for landscape layer weight static params
            StaticParameterTerrainLayerWeightBlendType,

            // Fix up None Named animation curve names,
            FixUpNoneNameAnimationCurves,

            // Ensure ActiveBoneIndices to have parents even not skinned for old assets
            EnsureActiveBoneIndicesToContainParents,

            // Serialize the instanced static mesh render data, to avoid building it at runtime
            SerializeInstancedStaticMeshRenderData,

            // Cache material quality node usage
            CachedMaterialQualityNodeUsage,

            // Font outlines no longer apply to drop shadows for new objects but we maintain the opposite way for backwards compat
            FontOutlineDropShadowFixup,

            // New skeletal mesh import workflow (Geometry only or animation only re-import )
            NewSkeletalMeshImporterWorkflow,

            // Migrate data from previous data structure to new one to support materials per LOD on the Landscape
            NewLandscapeMaterialPerLOD,

            // New Pose Asset data type
            RemoveUnnecessaryTracksFromPose,

            // Migrate Foliage TLazyObjectPtr to TSoftObjectPtr
            FoliageLazyObjPtrToSoftObjPtr,

            // TimelineTemplates store their derived names instead of dynamically generating
            // This code tied to this version was reverted and redone at a later date
            REVERTED_StoreTimelineNamesInTemplate,

            // Added BakePoseOverride for LOD setting
            AddBakePoseOverrideForSkeletalMeshReductionSetting,

            // TimelineTemplates store their derived names instead of dynamically generating
            StoreTimelineNamesInTemplate,

            // New Pose Asset data type
            WidgetStopDuplicatingAnimations,

            // Allow reducing of the base LOD, we need to store some imported model data so we can reduce again from the same data.
            AllowSkeletalMeshToReduceTheBaseLOD,

            // Curve Table size reduction
            ShrinkCurveTableSize,

            // Widgets upgraded with WidgetStopDuplicatingAnimations, may not correctly default-to-self for the widget parameter.
            WidgetAnimationDefaultToSelfFail,

            // HUDWidgets now require an element tag
            FortHUDElementNowRequiresTag,

            // Animation saved as bulk data when cooked
            FortMappedCookedAnimation,

            // Support Virtual Bone in Retarget Manager
            SupportVirtualBoneInRetargeting,

            // Fixup bad defaults in water metadata
            FixUpWaterMetadata,

            // Move the location of water metadata
            MoveWaterMetadataToActor,

            // Replaced lake collision component
            ReplaceLakeCollision,

            // Anim layer node names are now conformed by Guid
            AnimLayerGuidConformation,

            // Ocean collision component has become dynamic
            MakeOceanCollisionTransient,

            // FFieldPath will serialize the owner struct reference and only a short path to its property
            FFieldPathOwnerSerialization,

            // Simplified WaterBody post process material handling
            FixUpUnderwaterPostProcessMaterial,

            // A single water exclusion volume can now exclude N water bodies
            SupportMultipleWaterBodiesPerExclusionVolume,

            // Serialize rigvm operators one by one instead of the full byte code array to ensure determinism
            RigVMByteCodeDeterminism,

            // Serialize the physical materials generated by the render material
            LandscapePhysicalMaterialRenderData,

            // RuntimeVirtualTextureVolume fix transforms
            FixupRuntimeVirtualTextureVolume,

            // Retrieve water body collision components that were lost in cooked builds
            FixUpRiverCollisionComponents,

            // Fix duplicate spline mesh components on rivers
            FixDuplicateRiverSplineMeshCollisionComponents,

            // Indicates level has stable actor guids
            ContainsStableActorGUIDs,

            // Levelset Serialization support for BodySetup.
            LevelsetSerializationSupportForBodySetup,

            // Moving Chaos solver properties to allow them to exist in the project physics settings
            ChaosSolverPropertiesMoved,

            // Moving some UFortGameFeatureData properties and behaviors into the UGameFeatureAction pattern
            GameFeatureData_MovedComponentListAndCheats,

            // Add centrifugal forces for cloth
            ChaosClothAddfictitiousforces,

            // Chaos Convex StructureData supports different index sizes based on num verts/planes
            // Chaos FConvex uses array of FVec3s for vertices instead of particles
            // (Merged from //UE4/Main)
            ChaosConvexVariableStructureDataAndVerticesArray,

            // Remove the WaterVelocityHeightTexture dependency on MPC_Landscape and LandscapeWaterIndo
            RemoveLandscapeWaterInfo,

            // Added the weighted value property type to store the cloths weight maps' low/high ranges
            ChaosClothAddWeightedValue,

            // Added the Long Range Attachment stiffness weight map
            ChaosClothAddTetherStiffnessWeightMap,

            // Fix corrupted LOD transition maps
            ChaosClothFixLODTransitionMaps,

            // Enable a few more weight maps to better art direct the cloth simulation
            ChaosClothAddTetherScaleAndDragLiftWeightMaps,

            // Enable material (edge, bending, and area stiffness) weight maps
            ChaosClothAddMaterialWeightMaps,

            // Added bShowCurve for movie scene float channel serialization
            SerializeFloatChannelShowCurve,

            // Minimize slack waste by using a single array for grass data
            LandscapeGrassSingleArray,

            // Add loop counters to sequencer's compiled sub-sequence data
            AddedSubSequenceEntryWarpCounter,

            // Water plugin is now component-based rather than actor based
            WaterBodyComponentRefactor,

            // Cooked BPGC storing editor-only asset tags
            BPGCCookedEditorTags,

            // -----<new versions can be added above this line>-------------------------------------------------
            VersionPlusOne,
            LatestVersion = VersionPlusOne - 1
        }

        public static readonly FGuid GUID = new(0x601D1886, 0xAC644F84, 0xAA16D3DE, 0x0DEAC7D6);

        public static Type Get(FArchive Ar)
        {
            var ver = Ar.CustomVer(GUID);
            if (ver >= 0)
                return (Type) ver;

            return Ar.Game switch
            {
                < EGame.GAME_UE4_20 => Type.BeforeCustomVersionWasAdded,
                < EGame.GAME_UE4_21 => Type.CachedMaterialQualityNodeUsage,
                < EGame.GAME_UE4_22 => Type.FoliageLazyObjPtrToSoftObjPtr,
                < EGame.GAME_UE4_23 => Type.FortHUDElementNowRequiresTag,
                < EGame.GAME_UE4_24 => Type.SupportVirtualBoneInRetargeting,
                < EGame.GAME_UE4_26 => Type.AnimLayerGuidConformation,
                < EGame.GAME_UE4_27 => Type.ChaosSolverPropertiesMoved,
                < EGame.GAME_UE5_0 => Type.BPGCCookedEditorTags,
                _ => Type.LatestVersion
            };
        }
    }
}
