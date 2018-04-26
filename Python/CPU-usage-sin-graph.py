#!/usr/bin/python
# -*- coding: utf-8 -*-

import time
import math
from multiprocessing import Pool
from multiprocessing import cpu_count


def f(x):
    start = time.clock()
    piece = 50
    n = 1
    length = 0.5*math.sin(n * (3.14159/piece)) + 0.5
    print length
    while True:
        x * x
        end = time.clock()
        if end - start >= length:
            start = time.clock()
            n = n + 1
            length = 0.5*math.sin(n * (3.14159/piece)) + 0.5
            time.sleep(1-length)

if __name__ == '__main__':
    processes = cpu_count()
    print 'utilizing %d cores\n' % processes
    pool = Pool(processes)
    pool.map(f, range(processes))