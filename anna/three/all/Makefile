binary: main.o libworld.a libworld.so
	gcc -o binary main.o -L. -lworld -Wl,-rpath,.

main.o: main.c
	gcc -c main.c

libworld.a: list.o 
	ar cr libworld.a list.o 
	
libworld.so: list.o 
	gcc -shared -o libworld.so list.o 

list.o: list.c
	gcc -c -fPIC list.c

clean:
	rm -f *.o *.a binary