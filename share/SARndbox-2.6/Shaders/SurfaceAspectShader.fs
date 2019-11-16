/***********************************************************************
SurfaceAspectShader
***********************************************************************/

#extension GL_ARB_texture_rectangle : enable
#extension GL_EXT_gpu_shader4 : enable

uniform sampler2DRect pixelCornerElevationSampler;

void drawAspect(in vec2 fragCoord,inout vec4 baseColor)
	{
        float M_PI = 3.14159265358;
	    float val0=(texture2DRect(pixelCornerElevationSampler,vec2(fragCoord.x-1.0,fragCoord.y-1.0)).r);
	    float val1=(texture2DRect(pixelCornerElevationSampler,vec2(fragCoord.x,fragCoord.y-1.0)).r);
	    float val2=(texture2DRect(pixelCornerElevationSampler,vec2(fragCoord.x+1.0,fragCoord.y-1.0)).r);

	    float val3=(texture2DRect(pixelCornerElevationSampler,vec2(fragCoord.x-1.0,fragCoord.y)).r);
	    float val4=(texture2DRect(pixelCornerElevationSampler,vec2(fragCoord.x,fragCoord.y)).r);
	    float val5=(texture2DRect(pixelCornerElevationSampler,vec2(fragCoord.x+1.0,fragCoord.y)).r);

	    float val6=(texture2DRect(pixelCornerElevationSampler,vec2(fragCoord.x-1.0,fragCoord.y+1.0)).r);
	    float val7=(texture2DRect(pixelCornerElevationSampler,vec2(fragCoord.x,fragCoord.y+1.0)).r);
	    float val8=(texture2DRect(pixelCornerElevationSampler,vec2(fragCoord.x+1.0,fragCoord.y+1.0)).r);

	    float diffx=val2-val0+2.0*(val5-val3)+val8-val6;
	    float diffy=val6-val0+2.0*(val7-val1)+val8-val2;
	    float aspect=atan(diffy,-diffx);

	    float normalizedAspect = (aspect + M_PI)/(2*M_PI);

	    if ((normalizedAspect > 0) & (normalizedAspect < 1))
	        {
	            if (normalizedAspect < 0.0625 || normalizedAspect > 0.9375)
                    {
                        baseColor=vec4(1.0,0.0,0.0,0.0); //red
                    }
                else if(normalizedAspect < 0.1875)
                    {
                        baseColor=vec4(1.0,0.6471,0.0,0.0); //orange
                    }
                else if(normalizedAspect < 0.3125)
                    {
                        baseColor=vec4(1.0,1.0,0.0,0.0); //yellow
                    }
                else if(normalizedAspect < 0.4375)
                    {
                        baseColor=vec4(0.0,0.8039,0.0,0.0); //green
                    }
                else if(normalizedAspect < 0.5625)
                    {
                        baseColor=vec4(0.0,1.0,1.0,0.0); //blueish
                    }
                else if(normalizedAspect < 0.6875)
                    {
                        baseColor=vec4(0.0,0.0,1.0,0.0); //blue
                    }
                else if(normalizedAspect < 0.8125)
                    {
                        baseColor=vec4(0.0,0.0,0.702,0.0); //dark blue
                    }
                else if(normalizedAspect < 0.9375)
                    {
                        baseColor=vec4(0.9765,0.0039,0.7373,0.0); //pink
                    }
	        }
        else
            {
                baseColor=vec4(1,1,1,0.0);
            }

	}
