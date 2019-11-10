/***********************************************************************
SurfaceAddContourLines - Shader fragment to add topographic contour
lines extracted from a half-pixel offset 2D elevation map to a surface's
base color.
Copyright (c) 2012 Oliver Kreylos

This file is part of the Augmented Reality Sandbox (SARndbox).

The Augmented Reality Sandbox is free software; you can redistribute it
and/or modify it under the terms of the GNU General Public License as
published by the Free Software Foundation; either version 2 of the
License, or (at your option) any later version.

The Augmented Reality Sandbox is distributed in the hope that it will be
useful, but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
General Public License for more details.

You should have received a copy of the GNU General Public License along
with the Augmented Reality Sandbox; if not, write to the Free Software
Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
***********************************************************************/

#extension GL_ARB_texture_rectangle : enable

uniform sampler2DRect pixelCornerElevationSampler;

void drawSlopes(in vec2 fragCoord,inout vec4 baseColor)
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
	float slope=atan(sqrt(diffx*diffx+diffy*diffy)); 
	baseColor=vec4(1.0-slope,1.0-slope,1.0,0.0);
	
	}
