; ModuleID = 'obj\Release\120\android\compressed_assemblies.armeabi-v7a.ll'
source_filename = "obj\Release\120\android\compressed_assemblies.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.CompressedAssemblyDescriptor = type {
	i32,; uint32_t uncompressed_file_size
	i8,; bool loaded
	i8*; uint8_t* data
}

%struct.CompressedAssemblies = type {
	i32,; uint32_t count
	%struct.CompressedAssemblyDescriptor*; CompressedAssemblyDescriptor* descriptors
}
@__CompressedAssemblyDescriptor_data_0 = internal global [164864 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_1 = internal global [1185792 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_2 = internal global [109568 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_3 = internal global [140288 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_4 = internal global [54784 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_5 = internal global [212480 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_6 = internal global [25600 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_7 = internal global [386048 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_8 = internal global [6144 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_9 = internal global [318464 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_10 = internal global [142336 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_11 = internal global [8704 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_12 = internal global [40960 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_13 = internal global [152576 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_14 = internal global [14848 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_15 = internal global [15872 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_16 = internal global [16896 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_17 = internal global [36352 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_18 = internal global [12800 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_19 = internal global [26112 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_20 = internal global [1877504 x i8] zeroinitializer, align 1


; Compressed assembly data storage
@compressed_assembly_descriptors = internal global [21 x %struct.CompressedAssemblyDescriptor] [
	; 0
	%struct.CompressedAssemblyDescriptor {
		i32 164864, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([164864 x i8], [164864 x i8]* @__CompressedAssemblyDescriptor_data_0, i32 0, i32 0); data
	}, 
	; 1
	%struct.CompressedAssemblyDescriptor {
		i32 1185792, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1185792 x i8], [1185792 x i8]* @__CompressedAssemblyDescriptor_data_1, i32 0, i32 0); data
	}, 
	; 2
	%struct.CompressedAssemblyDescriptor {
		i32 109568, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([109568 x i8], [109568 x i8]* @__CompressedAssemblyDescriptor_data_2, i32 0, i32 0); data
	}, 
	; 3
	%struct.CompressedAssemblyDescriptor {
		i32 140288, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([140288 x i8], [140288 x i8]* @__CompressedAssemblyDescriptor_data_3, i32 0, i32 0); data
	}, 
	; 4
	%struct.CompressedAssemblyDescriptor {
		i32 54784, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([54784 x i8], [54784 x i8]* @__CompressedAssemblyDescriptor_data_4, i32 0, i32 0); data
	}, 
	; 5
	%struct.CompressedAssemblyDescriptor {
		i32 212480, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([212480 x i8], [212480 x i8]* @__CompressedAssemblyDescriptor_data_5, i32 0, i32 0); data
	}, 
	; 6
	%struct.CompressedAssemblyDescriptor {
		i32 25600, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([25600 x i8], [25600 x i8]* @__CompressedAssemblyDescriptor_data_6, i32 0, i32 0); data
	}, 
	; 7
	%struct.CompressedAssemblyDescriptor {
		i32 386048, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([386048 x i8], [386048 x i8]* @__CompressedAssemblyDescriptor_data_7, i32 0, i32 0); data
	}, 
	; 8
	%struct.CompressedAssemblyDescriptor {
		i32 6144, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([6144 x i8], [6144 x i8]* @__CompressedAssemblyDescriptor_data_8, i32 0, i32 0); data
	}, 
	; 9
	%struct.CompressedAssemblyDescriptor {
		i32 318464, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([318464 x i8], [318464 x i8]* @__CompressedAssemblyDescriptor_data_9, i32 0, i32 0); data
	}, 
	; 10
	%struct.CompressedAssemblyDescriptor {
		i32 142336, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([142336 x i8], [142336 x i8]* @__CompressedAssemblyDescriptor_data_10, i32 0, i32 0); data
	}, 
	; 11
	%struct.CompressedAssemblyDescriptor {
		i32 8704, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([8704 x i8], [8704 x i8]* @__CompressedAssemblyDescriptor_data_11, i32 0, i32 0); data
	}, 
	; 12
	%struct.CompressedAssemblyDescriptor {
		i32 40960, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([40960 x i8], [40960 x i8]* @__CompressedAssemblyDescriptor_data_12, i32 0, i32 0); data
	}, 
	; 13
	%struct.CompressedAssemblyDescriptor {
		i32 152576, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([152576 x i8], [152576 x i8]* @__CompressedAssemblyDescriptor_data_13, i32 0, i32 0); data
	}, 
	; 14
	%struct.CompressedAssemblyDescriptor {
		i32 14848, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14848 x i8], [14848 x i8]* @__CompressedAssemblyDescriptor_data_14, i32 0, i32 0); data
	}, 
	; 15
	%struct.CompressedAssemblyDescriptor {
		i32 15872, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15872 x i8], [15872 x i8]* @__CompressedAssemblyDescriptor_data_15, i32 0, i32 0); data
	}, 
	; 16
	%struct.CompressedAssemblyDescriptor {
		i32 16896, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([16896 x i8], [16896 x i8]* @__CompressedAssemblyDescriptor_data_16, i32 0, i32 0); data
	}, 
	; 17
	%struct.CompressedAssemblyDescriptor {
		i32 36352, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([36352 x i8], [36352 x i8]* @__CompressedAssemblyDescriptor_data_17, i32 0, i32 0); data
	}, 
	; 18
	%struct.CompressedAssemblyDescriptor {
		i32 12800, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([12800 x i8], [12800 x i8]* @__CompressedAssemblyDescriptor_data_18, i32 0, i32 0); data
	}, 
	; 19
	%struct.CompressedAssemblyDescriptor {
		i32 26112, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([26112 x i8], [26112 x i8]* @__CompressedAssemblyDescriptor_data_19, i32 0, i32 0); data
	}, 
	; 20
	%struct.CompressedAssemblyDescriptor {
		i32 1877504, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1877504 x i8], [1877504 x i8]* @__CompressedAssemblyDescriptor_data_20, i32 0, i32 0); data
	}
], align 4; end of 'compressed_assembly_descriptors' array


; compressed_assemblies
@compressed_assemblies = local_unnamed_addr global %struct.CompressedAssemblies {
	i32 21, ; count
	%struct.CompressedAssemblyDescriptor* getelementptr inbounds ([21 x %struct.CompressedAssemblyDescriptor], [21 x %struct.CompressedAssemblyDescriptor]* @compressed_assembly_descriptors, i32 0, i32 0); descriptors
}, align 4


!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-3 @ 030cd63c06d95a6b0d0f563fe9b9d537f84cb84b"}
