#include <stdio.h>
#include <math.h>

int main(void){
	int iteration = 0; //Чтобы зациклить выполнение программы
	double term = 0; //слогаемое

	while(iteration++ < 1000000){
		double e = 0.0000001; //константа для вычисления (пока слогаемое больше цикл do работает)

		//fib values
		double fn[2] = {1,1}; //устанавливаем значения fib. на 3 проход(по варианту)
		double nextFib = 0; //сюда записывается следующее значение фиб-и

		//factorial
		double factorial = 1;

		//pow
		double pow = 5;
		double i = 1;

		do{
      nextFib = fn[0] + fn[1];
      fn[0] = fn[1];
      fn[1] = nextFib;

			factorial = factorial * i; //i увеличивается каждую итерацию что делат это выражение ф-ом (1*2*3*4...)

      pow = pow * 5;

      term = nextFib / (pow * factorial); //sqrt разрешён вроде
			i++;
		}while (term > e);
	}
}
