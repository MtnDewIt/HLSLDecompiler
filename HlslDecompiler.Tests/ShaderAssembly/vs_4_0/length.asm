//
// Generated by Microsoft (R) HLSL Shader Compiler 6.3.9600.16384
//
//
//
// Input signature:
//
// Name                 Index   Mask Register SysValue  Format   Used
// -------------------- ----- ------ -------- -------- ------- ------
// POSITION                 0   xyzw        0     NONE   float   xyzw
// POSITION                 1   xyzw        1     NONE   float   xyz 
// POSITION                 2   xyzw        2     NONE   float   xyzw
//
//
// Output signature:
//
// Name                 Index   Mask Register SysValue  Format   Used
// -------------------- ----- ------ -------- -------- ------- ------
// POSITION                 0   xyzw        0     NONE   float   xyzw
//
vs_4_0
dcl_input v0.xyzw
dcl_input v1.xyz
dcl_input v2.xyzw
dcl_output o0.xyzw
dcl_temps 1
add r0.xyzw, v2.xyzw, l(2.000000, 2.000000, 2.000000, 2.000000)
dp4 r0.x, r0.xyzw, r0.xyzw
sqrt r0.x, r0.x
mul o0.w, r0.x, l(-5.000000)
dp2 r0.x, v2.xyxx, v2.xyxx
sqrt r0.x, r0.x
mov o0.z, -r0.x
dp4 r0.x, v0.xyzw, v0.xyzw
sqrt o0.x, r0.x
dp3 r0.x, v1.xyzx, v1.xyzx
sqrt o0.y, r0.x
ret 
// Approximately 12 instruction slots used
