# Super Mario 64 Tools
This repository is a dumping ground for any miscellaneous tools I write for editing Super Mario 64

### N64.TextureTool
This tool can do a few useful things with textures.

###### Convert
Convert an image to the RGBA5551 format commonly used in Nintendo 64 games and save it to a file. It technically works with images of any size, but it's only useful for texture sizes that you can actually use on an N64. If the input image is an animated gif, each individual frame will end up in the output file in sequential order. This can be combined with some custom assembly (or C code) to create animated textures.

###### Split
Split a high-resolution image into many smaller N64 compatible fragments. An &ast;.obj file is generated for use in modeling software. Currently, the input image must have a width that is a multiple of 64 and a height that is a multiple of 32

###### Cake
Creates a replacement end cake screen without any of the graphical jank associated with SM64 Cake Eater. It takes an input image, resizes it to 320x240, then spits out a file that you can import into your ROM to replace the end screen. This file replaces the texture data, vertex data, and the Fast3D display list. It should be imported at the exact address where the vanilla end screen texture data begins. For ROM Manager roms, this is at offset 0x010BA810.

#Other notes
There are references to project files that are not included in this repository. These projects are not needed for building the above tools. They aren't included because they are not ready for public consumption. 
These tools were written quickly with the goal of accomplishing specific tasks. As such, the code quality may be poor.
