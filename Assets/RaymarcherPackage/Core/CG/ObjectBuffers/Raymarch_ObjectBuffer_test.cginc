//-----Registered Object Parameters
float4x4 _obj0Model;
float4x4 _obj1Model;
float4x4 _obj2Model;
float4x4 _obj3Model;
float4x4 _obj4Model;
float4x4 _obj5Model;
float4x4 _obj6Model;
float4x4 _obj7Model;
float4x4 _obj8Model;
float4x4 _obj9Model;

float obj0sm,enabled0;
float4 size0;
float obj1sm,enabled1;
float4 size1;
float obj2sm,enabled2;
float4 size2;
float obj3sm,enabled3;
float4 size3;
float obj4sm,enabled4;
float4 size4;
float obj5sm,enabled5;
float4 size5;
float obj6sm,enabled6;
float4 size6;
float obj7sm,enabled7;
float4 size7;
float obj8sm,enabled8;
float4 size8;
float obj9sm,enabled9;
float4 size9;

float3 color0;
float3 color1;
float3 color2;
float3 color3;
float3 color4;
float3 color5;
float3 color6;
float3 color7;
float3 color8;
float3 color9;

float4 fragSize0;
float3 DirfragSize0;
float fragEnabled0;
float4 fragSize1;
float3 DirfragSize1;
float fragEnabled1;
float4 fragSize2;
float3 DirfragSize2;
float fragEnabled2;
float4 fragSize3;
float3 DirfragSize3;
float fragEnabled3;
float4 fragSize4;
float3 DirfragSize4;
float fragEnabled4;
float4 fragSize5;
float3 DirfragSize5;
float fragEnabled5;
float4 fragSize6;
float3 DirfragSize6;
float fragEnabled6;
float4 fragSize7;
float3 DirfragSize7;
float fragEnabled7;
float4 fragSize8;
float3 DirfragSize8;
float fragEnabled8;
float4 fragSize9;
float3 DirfragSize9;
float fragEnabled9;

//-----Registered Shape Branches
float4 MAS_ShapeGenerator(float3 center)
{
   float4 result;

   float4 obj0 = GENERATOR_SHAPE(center,color0,size0 * enabled0,_obj0Model);
   obj0 = OP_Fragment(obj0,fragSize0,DirfragSize0,center,fragEnabled0);

   float4 obj1 = GENERATOR_SHAPE(center,color1,size1 * enabled1,_obj1Model);
   obj1 = OP_Fragment(obj1,fragSize1,DirfragSize1,center,fragEnabled1);

   float4 obj2 = GENERATOR_SHAPE(center,color2,size2 * enabled2,_obj2Model);
   obj2 = OP_Fragment(obj2,fragSize2,DirfragSize2,center,fragEnabled2);

   float4 obj3 = GENERATOR_SHAPE(center,color3,size3 * enabled3,_obj3Model);
   obj3 = OP_Fragment(obj3,fragSize3,DirfragSize3,center,fragEnabled3);

   float4 obj4 = GENERATOR_SHAPE(center,color4,size4 * enabled4,_obj4Model);
   obj4 = OP_Fragment(obj4,fragSize4,DirfragSize4,center,fragEnabled4);

   float4 obj5 = GENERATOR_SHAPE(center,color5,size5 * enabled5,_obj5Model);
   obj5 = OP_Fragment(obj5,fragSize5,DirfragSize5,center,fragEnabled5);

   float4 obj6 = GENERATOR_SHAPE(center,color6,size6 * enabled6,_obj6Model);
   obj6 = OP_Fragment(obj6,fragSize6,DirfragSize6,center,fragEnabled6);

   float4 obj7 = GENERATOR_SHAPE(center,color7,size7 * enabled7,_obj7Model);
   obj7 = OP_Fragment(obj7,fragSize7,DirfragSize7,center,fragEnabled7);

   float4 obj8 = GENERATOR_SHAPE(center,color8,size8 * enabled8,_obj8Model);
   obj8 = OP_Fragment(obj8,fragSize8,DirfragSize8,center,fragEnabled8);

   float4 obj9 = GEN_FRAC_Apollonian(center,size9.xyz,_obj9Model,color9);
   obj9 = OP_Fragment(obj9,fragSize9,DirfragSize9,center,fragEnabled9);

//-----Registered Advanced Operators
//Groups of obj0
   float4 group0 = OP_SmoothSubtraction(obj2,obj0,obj2sm);
   float4 group1 = OP_SmoothSubtraction(obj5,obj0,obj5sm);
   float4 group2 = OP_SmoothSubtraction(obj7,obj0,obj7sm);
   float4 group3 = OP_SmoothSubtraction(obj8,obj0,obj8sm);
   float4 group4 = OP_SmoothSubtraction(obj9,obj0,obj9sm);

//-----Connected Advanced Operators - Straight Unions
//Connection Group of obj0
   float4 group5 = OP_StraightUnion(group0,group1,_MASrenderColorSmoothness);
   float4 group6 = OP_StraightUnion(group5,group2,_MASrenderColorSmoothness);
   float4 group7 = OP_StraightUnion(group6,group3,_MASrenderColorSmoothness);
   float4 group8 = OP_StraightUnion(group7,group4,_MASrenderColorSmoothness);

//-----Connected Advanced Operators - Smooth Unions


//-----Registered Final Groups & Single Objects
   float4 group9 = OP_SmoothUnion(group8,obj1,_MASrenderSmoothness);
   float4 group10 = OP_SmoothUnion(group9,obj3,_MASrenderSmoothness);
   float4 group11 = OP_SmoothUnion(group10,obj4,_MASrenderSmoothness);
   float4 group12 = OP_SmoothUnion(group11,obj6,_MASrenderSmoothness);
   result = group12;
   return result;
}