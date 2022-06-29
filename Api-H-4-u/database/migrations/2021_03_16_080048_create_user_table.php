<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateUserTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void 
     */
    public function up()
    {
        Schema::create('users', function (Blueprint $table) {
            $table->integer('Id',100);
            $table->string('Email',50)->unique();
            $table->string('Password');
            $table->string('Nome',50);
            $table->string('Genero'); 
            $table->date('Dtn');
            $table->string('Regiao',50);
            $table->string('Adm',)->nullable();
            $table->string('Estado',50)->nullable();
            $table->string('Morada',50);
            $table->string('Interesses',50)->nullable();
            $table->timestamps();
        }); 
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('users');
    }
}
