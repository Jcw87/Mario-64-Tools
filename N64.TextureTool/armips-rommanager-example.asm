.n64 
.open "in.z64", "out.z64", 0 

// End cake replacement
.headersize 0
.org 0x010BA810
.import "endcake.bin"

.close
