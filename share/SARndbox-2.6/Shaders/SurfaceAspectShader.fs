/***********************************************************************
SurfaceAspectShader
***********************************************************************/

#extension GL_ARB_texture_rectangle : enable

uniform sampler2DRect pixelCornerElevationSampler;

void drawAspect(in vec2 fragCoord,inout vec4 baseColor)
	{

	float val0=(texture2DRect(pixelCornerElevationSampler,vec2(fragCoord.x-1.0,fragCoord.y-1.0)).r);
	float val1=(texture2DRect(pixelCornerElevationSampler,vec2(fragCoord.x,fragCoord.y-1.0)).r);
	float val2=(texture2DRect(pixelCornerElevationSampler,vec2(fragCoord.x+1.0,fragCoord.y-1.0)).r);

	float val3=(texture2DRect(pixelCornerElevationSampler,vec2(fragCoord.x-1.0,fragCoord.y)).r);
	float val4=(texture2DRect(pixelCornerElevationSampler,vec2(fragCoord.x,fragCoord.y)).r);
	float val5=(texture2DRect(pixelCornerElevationSampler,vec2(fragCoord.x+1.0,fragCoord.y)).r);
	
	float val6=(texture2DRect(pixelCornerElevationSampler,vec2(fragCoord.x-1.0,fragCoord.y+1.0)).r);
	float val7=(texture2DRect(pixelCornerElevationSampler,vec2(fragCoord.x,fragCoord.y+1.0)).r);
	float val8=(texture2DRect(pixelCornerElevationSampler,vec2(fragCoord.x+1.0,fragCoord.y+1.0)).r);

	float diffx=val2-val0+2.0*(val5-val4)+val8-val6;
	float diffy=val6-val0+2.0*(val7-val1)+val8-val2;
	float aspect=atan2(diffy,-diffx);
	baseColor=vec4(1-aspect,aspect,1-aspect,0.0);
	
	}
