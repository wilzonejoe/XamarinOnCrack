
import 'dart:async';

import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:injectable/injectable.dart';

import 'package:flutter_module/services/Interfaces/i_navigation_service.dart';

part 'home_page_event.dart';
part 'home_page_state.dart';

part 'home_page_bloc.freezed.dart';

@injectable
class HomePageBloc extends Bloc<HomePageEvent, HomePageState> {
  final INavigationService _navigationService;

  HomePageBloc(this._navigationService) : super(const HomePageState.initial());

  @override
  Stream<HomePageState> mapEventToState(
      HomePageEvent event,
      ) async* {

  }
}
